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

using C = GooglePlayGames.Native.Cwrapper.PlayerManager;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native {
internal class PlayerManager {

    private readonly GameServices mGameServices;

    internal PlayerManager (GameServices services) {
        mGameServices = Misc.CheckNotNull(services);
    }

    internal void FetchSelf(Action<FetchSelfResponse> callback) {
        C.PlayerManager_FetchSelf(mGameServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK,
            InternalFetchSelfCallback, Callbacks.ToIntPtr(callback, FetchSelfResponse.FromPointer));
    }

    [AOT.MonoPInvokeCallback(typeof(C.FetchSelfCallback))]
    private static void InternalFetchSelfCallback(IntPtr response, IntPtr data) {
        Callbacks.PerformInternalCallback("PlayerManager#InternalFetchSelfCallback",
            Callbacks.Type.Temporary, response, data);
    }

    internal class FetchSelfResponse : BaseReferenceHolder {
        internal FetchSelfResponse (IntPtr selfPointer) : base(selfPointer) {
        }

        internal Status.ResponseStatus Status() {
            return C.PlayerManager_FetchSelfResponse_GetStatus(SelfPtr());
        }

        internal NativePlayer Self() {
            return new NativePlayer(C.PlayerManager_FetchSelfResponse_GetData(SelfPtr()));
        }

        protected override void CallDispose(HandleRef selfPointer) {
            C.PlayerManager_FetchSelfResponse_Dispose(SelfPtr());
        }

        internal static FetchSelfResponse FromPointer(IntPtr selfPointer) {
            if (PInvokeUtilities.IsNull(selfPointer)) {
                return null;
            }

            return new FetchSelfResponse(selfPointer);
        }
    }
}
}


#endif
