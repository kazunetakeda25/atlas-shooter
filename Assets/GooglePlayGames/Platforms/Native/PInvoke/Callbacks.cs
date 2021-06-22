/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if (UNITY_ANDROID || UNITY_IPHONE)
using System;
using System.Runtime.InteropServices;
using System.Text;
using GooglePlayGames.OurUtils;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke {
static class Callbacks {

    internal static readonly Action<CommonErrorStatus.UIStatus> NoopUICallback = status => {
        Logger.d("Received UI callback: " + status);
    };

    internal delegate void ShowUICallbackInternal(CommonErrorStatus.UIStatus status, IntPtr data);

    internal static IntPtr ToIntPtr<T>(Action<T> callback, Func<IntPtr, T> conversionFunction)
        where T : BaseReferenceHolder {
        Action<IntPtr> pointerReceiver = result => {
            using (T converted = conversionFunction(result)) {
                if (callback != null) {
                    callback(converted);
                }
            }
        };

        return ToIntPtr(pointerReceiver);
    }

    internal static IntPtr ToIntPtr(Delegate callback) {
        if (callback == null) {
            return IntPtr.Zero;
        }

        // Once the callback is passed off to native, we don't retain a reference to it - which
        // means it's eligible for garbage collecting or being moved around by the runtime. If
        // the garbage collector runs before the native code invokes the callback, chaos will
        // ensue.
        //
        // To handle this, we manually pin the callback in memory (this means it cannot be
        // collected or moved) - the GCHandle will be freed when the callback returns the and
        // handle is converted back to callback via IntPtrToCallback.
        var handle = GCHandle.Alloc(callback, GCHandleType.Pinned);

        return GCHandle.ToIntPtr(handle);
    }


    internal static T IntPtrToTempCallback<T>(IntPtr handle) where T : class {
        return IntPtrToCallback<T>(handle, true);
    }

    private static T IntPtrToCallback<T>(IntPtr handle, bool unpinHandle) where T : class {
        if (PInvokeUtilities.IsNull(handle)) {
            return null;
        }

        var gcHandle = GCHandle.FromIntPtr(handle);
        try {
            return (T)gcHandle.Target;
        } catch(System.InvalidCastException e) {
            Logger.e("GC Handle pointed to unexpected type: " + gcHandle.Target.ToString() +
                ". Expected " +  typeof(T));
            throw e;
        } finally {
            if (unpinHandle) {
                gcHandle.Free();
            }
        }
    }

    // TODO(hsakai): Better way of handling this.
    internal static T IntPtrToPermanentCallback<T>(IntPtr handle) where T : class {
        return IntPtrToCallback<T>(handle, false);
    }

    [AOT.MonoPInvokeCallback(typeof(ShowUICallbackInternal))]
    internal static void InternalShowUICallback(CommonErrorStatus.UIStatus status, IntPtr data) {
        Logger.d("Showing UI Internal callback: " + status);
        var callback = IntPtrToTempCallback<Action<CommonErrorStatus.UIStatus>>(data);

        try {
            callback(status);
        } catch (Exception e) {
            Logger.e("Error encountered executing InternalShowAllUICallback. " +
                "Smothering to avoid passing exception into Native: " + e);
        }
    }

    internal enum Type { Permanent, Temporary };

    internal static void PerformInternalCallback(string callbackName, Type callbackType,
        IntPtr response, IntPtr userData) {
        Logger.d("Entering internal callback for " + callbackName);

        Action<IntPtr> callback = callbackType == Type.Permanent
            ? IntPtrToPermanentCallback<Action<IntPtr>>(userData)
            : IntPtrToTempCallback<Action<IntPtr>>(userData);

        if (callback == null) {
            return;
        }

        try {
            callback(response);
        } catch (Exception e) {
            Logger.e("Error encountered executing " + callbackName + ". " +
            "Smothering to avoid passing exception into Native: " + e);
        }
    }

    internal static Action<T> AsOnGameThreadCallback<T>(Action<T> toInvokeOnGameThread) {
        return result => {
            if (toInvokeOnGameThread == null) {
                return;
            }

            PlayGamesHelperObject.RunOnGameThread(() => toInvokeOnGameThread(result));
        };
    }

    internal static Action<T1, T2> AsOnGameThreadCallback<T1, T2>(
        Action<T1, T2> toInvokeOnGameThread) {
        return (result1, result2) => {
            if (toInvokeOnGameThread == null) {
                return;
            }

            PlayGamesHelperObject.RunOnGameThread(() => toInvokeOnGameThread(result1, result2));
        };
    }

}
}


#endif
