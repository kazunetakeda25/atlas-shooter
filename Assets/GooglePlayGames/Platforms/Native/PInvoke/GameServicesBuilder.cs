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
using GooglePlayGames.OurUtils;
using GooglePlayGames.Native.Cwrapper;

using C = GooglePlayGames.Native.Cwrapper.Builder;
using Types = GooglePlayGames.Native.Cwrapper.Types;

namespace GooglePlayGames.Native.PInvoke {
internal class GameServicesBuilder : BaseReferenceHolder {

    internal delegate void AuthFinishedCallback(Types.AuthOperation operation,
        CommonErrorStatus.AuthStatus status);

    internal delegate void AuthStartedCallback(Types.AuthOperation operation);

    private GameServicesBuilder (IntPtr selfPointer) : base(selfPointer) {
        InternalHooks.InternalHooks_ConfigureForUnityPlugin(SelfPtr());
    }

    internal void SetOnAuthFinishedCallback(AuthFinishedCallback callback) {
        C.GameServices_Builder_SetOnAuthActionFinished(SelfPtr(), InternalAuthFinishedCallback,
            Callbacks.ToIntPtr(callback));
    }

    internal void EnableSnapshots() {
        C.GameServices_Builder_EnableSnapshots(SelfPtr());
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnAuthActionFinishedCallback))]
    private static void InternalAuthFinishedCallback(Types.AuthOperation op,
        CommonErrorStatus.AuthStatus status, IntPtr data) {

        AuthFinishedCallback callback =
            Callbacks.IntPtrToPermanentCallback<AuthFinishedCallback>(data);

        if (callback == null) {
            return;
        }

        try {
            callback(op, status);
        } catch (Exception e) {
            Logger.e("Error encountered executing InternalAuthFinishedCallback. " +
            "Smothering to avoid passing exception into Native: " + e);
        }
    }

    internal void SetOnAuthStartedCallback(AuthStartedCallback callback) {
        C.GameServices_Builder_SetOnAuthActionStarted(SelfPtr(), InternalAuthStartedCallback,
            Callbacks.ToIntPtr(callback));
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnAuthActionStartedCallback))]
    private static void InternalAuthStartedCallback(Types.AuthOperation op, IntPtr data) {
        AuthStartedCallback callback =
            Callbacks.IntPtrToPermanentCallback<AuthStartedCallback>(data);

        try {
            if (callback != null) {
                callback(op);
            }
        } catch (Exception e) {
            Logger.e("Error encountered executing InternalAuthStartedCallback. " +
                "Smothering to avoid passing exception into Native: " + e);
        }
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.GameServices_Builder_Dispose(selfPointer);
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnTurnBasedMatchEventCallback))]
    private static void InternalOnTurnBasedMatchEventCallback(Types.MultiplayerEvent eventType,
        string matchId, IntPtr match, IntPtr userData) {
        var callback = Callbacks.IntPtrToPermanentCallback
            <Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch>>(userData);
        using (var nativeMatch = NativeTurnBasedMatch.FromPointer(match)) {
            try {
                if (callback != null) {
                    callback(eventType, matchId, nativeMatch);
                }
            } catch (Exception e) {
                Logger.e("Error encountered executing InternalOnTurnBasedMatchEventCallback. " +
                "Smothering to avoid passing exception into Native: " + e);
            }
        }
    }

    internal void SetOnTurnBasedMatchEventCallback(
        Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch> callback) {
        IntPtr callbackPointer = Callbacks.ToIntPtr(callback);
        C.GameServices_Builder_SetOnTurnBasedMatchEvent(SelfPtr(),
            InternalOnTurnBasedMatchEventCallback, callbackPointer);
    }

    [AOT.MonoPInvokeCallback(typeof(C.OnMultiplayerInvitationEventCallback))]
    private static void InternalOnMultiplayerInvitationEventCallback(
        Types.MultiplayerEvent eventType, string matchId, IntPtr match, IntPtr userData) {
        var callback = Callbacks.IntPtrToPermanentCallback
            <Action<Types.MultiplayerEvent, string, MultiplayerInvitation>>(userData);

        using (var nativeInvitation = MultiplayerInvitation.FromPointer(match)) {
            try {
                if (callback != null) {
                    callback(eventType, matchId, nativeInvitation);
                }
            } catch (Exception e) {
                Logger.e("Error encountered executing " +
                    "InternalOnMultiplayerInvitationEventCallback. " +
                    "Smothering to avoid passing exception into Native: " + e);
            }
        }
    }

    internal void SetOnMultiplayerInvitationEventCallback(
        Action<Types.MultiplayerEvent, string, MultiplayerInvitation> callback) {
        IntPtr callbackPointer = Callbacks.ToIntPtr(callback);
        C.GameServices_Builder_SetOnMultiplayerInvitationEvent(SelfPtr(),
            InternalOnMultiplayerInvitationEventCallback, callbackPointer);
    }

    internal GameServices Build(PlatformConfiguration configRef) {
        IntPtr pointer = C.GameServices_Builder_Create(SelfPtr(),
            HandleRef.ToIntPtr(configRef.AsHandle()));

        if (pointer.Equals(IntPtr.Zero)) {
            // TODO(hsakai): For now, explode noisily. In the actual plugin, this probably
            // should result in something besides an exception.
            throw new System.InvalidOperationException("There was an error creating a " +
                "GameServices object. Check for log errors from GamesNativeSDK");
        }

        return new GameServices(pointer);
    }

    internal static GameServicesBuilder Create() {
        return new GameServicesBuilder(C.GameServices_Builder_Construct());
    }
}
}


#endif
