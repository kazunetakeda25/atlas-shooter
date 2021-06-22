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
using GooglePlayGames.Native.PInvoke;
using System.Runtime.InteropServices;
using GooglePlayGames.OurUtils;
using System.Collections.Generic;
using GooglePlayGames.Native.Cwrapper;

using C = GooglePlayGames.Native.Cwrapper.RealTimeEventListenerHelper;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class RealTimeEventListenerHelper : BaseReferenceHolder {


    internal RealTimeEventListenerHelper(IntPtr selfPointer) : base(selfPointer) {
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.RealTimeEventListenerHelper_Dispose(selfPointer);
    }

    internal RealTimeEventListenerHelper SetOnRoomStatusChangedCallback(
        Action<NativeRealTimeRoom> callback) {
        C.RealTimeEventListenerHelper_SetOnRoomStatusChangedCallback(SelfPtr(),
            InternalOnRoomStatusChangedCallback,
            ToCallbackPointer(callback));
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnRoomStatusChangedCallback))]
    internal static void InternalOnRoomStatusChangedCallback(IntPtr response, IntPtr data) {
        Callbacks.PerformInternalCallback(
            "RealTimeEventListenerHelper#InternalOnRoomStatusChangedCallback",
            Callbacks.Type.Permanent, response, data);
    }

    internal RealTimeEventListenerHelper SetOnRoomConnectedSetChangedCallback(
        Action<NativeRealTimeRoom> callback) {
        C.RealTimeEventListenerHelper_SetOnRoomConnectedSetChangedCallback(SelfPtr(),
            InternalOnRoomConnectedSetChangedCallback,
            ToCallbackPointer(callback));
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnRoomConnectedSetChangedCallback))]
    internal static void InternalOnRoomConnectedSetChangedCallback(IntPtr response, IntPtr data) {
        Callbacks.PerformInternalCallback(
            "RealTimeEventListenerHelper#InternalOnRoomConnectedSetChangedCallback",
            Callbacks.Type.Permanent, response, data);
    }

    internal RealTimeEventListenerHelper SetOnP2PConnectedCallback(
        Action<NativeRealTimeRoom, MultiplayerParticipant> callback) {
        C.RealTimeEventListenerHelper_SetOnP2PConnectedCallback(SelfPtr(),
            InternalOnP2PConnectedCallback,
            Callbacks.ToIntPtr(callback));
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnP2PConnectedCallback))]
    internal static void InternalOnP2PConnectedCallback(
        IntPtr room, IntPtr participant, IntPtr data) {
        PerformRoomAndParticipantCallback(
            "InternalOnP2PConnectedCallback", room, participant, data);
    }

    internal RealTimeEventListenerHelper SetOnP2PDisconnectedCallback(
        Action<NativeRealTimeRoom, MultiplayerParticipant> callback) {
        C.RealTimeEventListenerHelper_SetOnP2PDisconnectedCallback(SelfPtr(),
            InternalOnP2PDisconnectedCallback,
            Callbacks.ToIntPtr(callback));
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnP2PDisconnectedCallback))]
    internal static void InternalOnP2PDisconnectedCallback(
        IntPtr room, IntPtr participant, IntPtr data) {
        PerformRoomAndParticipantCallback(
            "InternalOnP2PDisconnectedCallback", room, participant, data);
    }

    internal RealTimeEventListenerHelper SetOnParticipantStatusChangedCallback(
        Action<NativeRealTimeRoom, MultiplayerParticipant> callback) {
        C.RealTimeEventListenerHelper_SetOnParticipantStatusChangedCallback(SelfPtr(),
            InternalOnParticipantStatusChangedCallback,
            Callbacks.ToIntPtr(callback));
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnParticipantStatusChangedCallback))]
    internal static void InternalOnParticipantStatusChangedCallback(
        IntPtr room, IntPtr participant, IntPtr data) {
        PerformRoomAndParticipantCallback(
            "InternalOnParticipantStatusChangedCallback", room, participant, data);
    }

    internal static void PerformRoomAndParticipantCallback(string callbackName,
        IntPtr room, IntPtr participant, IntPtr data) {
        Logger.d("Entering " + callbackName);

        try {
            // This is a workaround to the fact that we're lacking proper copy constructors -
            // see comment below.
            var nativeRoom = NativeRealTimeRoom.FromPointer(room);
            using (var nativeParticipant = MultiplayerParticipant.FromPointer(participant)) {
                var callback = Callbacks.IntPtrToPermanentCallback
                        <Action<NativeRealTimeRoom, MultiplayerParticipant>>(data);
                if (callback != null) {
                    callback(nativeRoom, nativeParticipant);
                }
            }
        } catch (Exception e) {
            Logger.e("Error encountered executing " + callbackName + ". " +
            "Smothering to avoid passing exception into Native: " + e);
        }
    }

    internal RealTimeEventListenerHelper SetOnDataReceivedCallback(
        Action<NativeRealTimeRoom, MultiplayerParticipant, byte[], bool> callback) {
        IntPtr onData = Callbacks.ToIntPtr(callback);

        Logger.d("OnData Callback has addr: " + onData.ToInt64());

        C.RealTimeEventListenerHelper_SetOnDataReceivedCallback(SelfPtr(),
            InternalOnDataReceived, onData);
        return this;
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnDataReceivedCallback))]
    internal static void InternalOnDataReceived(
        IntPtr room, IntPtr participant, IntPtr data, UIntPtr dataLength, bool isReliable,
        IntPtr userData) {
        Logger.d("Entering InternalOnDataReceived: " + userData.ToInt64());

        var callback = Callbacks.IntPtrToPermanentCallback
            <Action<NativeRealTimeRoom, MultiplayerParticipant, byte[], bool>>(userData);

        using (var nativeRoom = NativeRealTimeRoom.FromPointer(room)) {
            using (var nativeParticipant = MultiplayerParticipant.FromPointer(participant)) {
                if (callback == null) {
                    return;
                }

                byte[] convertedData = null;

                if (dataLength.ToUInt64() != 0) {
                    convertedData = new byte[dataLength.ToUInt32()];
                    Marshal.Copy(data, convertedData, 0, (int) dataLength.ToUInt32());
                }

                try {
                    callback(nativeRoom, nativeParticipant, convertedData, isReliable);
                } catch (Exception e) {
                    Logger.e("Error encountered executing InternalOnDataReceived. " +
                    "Smothering to avoid passing exception into Native: " + e);
                }
            }
        }
    }

    // This is a workaround to the fact that we're lacking proper copy constructors on the cwrapper
    // structs. Clients of the RealTimeEventListener need to hold long-lived references to the
    // room returned by the callback, but the default implementation of the utility callback method
    // cleans up all arguments to the callback. This can be gotten rid of when copy constructors
    // are present in the native sdk.
    private static IntPtr ToCallbackPointer(Action<NativeRealTimeRoom> callback) {
        Action<IntPtr> pointerReceiver = result => {
            NativeRealTimeRoom converted = NativeRealTimeRoom.FromPointer(result);
            if (callback != null) {
                callback(converted);
            } else {
                if (converted != null) {
                    converted.Dispose();
                }
            }
        };

        return Callbacks.ToIntPtr(pointerReceiver);
    }

    internal static RealTimeEventListenerHelper Create() {
        return new RealTimeEventListenerHelper(C.RealTimeEventListenerHelper_Construct());
    }
}
}

#endif
