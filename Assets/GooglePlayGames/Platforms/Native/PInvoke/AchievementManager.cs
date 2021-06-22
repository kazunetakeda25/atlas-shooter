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

using C = GooglePlayGames.Native.Cwrapper.AchievementManager;


namespace GooglePlayGames.Native.PInvoke {
internal class AchievementManager {

    private readonly GameServices mServices;

    internal AchievementManager (GameServices services) {
        mServices = Misc.CheckNotNull(services);
    }

    internal void ShowAllUI(Action<CommonErrorStatus.UIStatus> callback) {
        Misc.CheckNotNull(callback);
        C.AchievementManager_ShowAllUI(mServices.AsHandle(),
            Callbacks.InternalShowUICallback, Callbacks.ToIntPtr(callback));
    }

    internal void FetchAll(Action<FetchAllResponse> callback) {
        Misc.CheckNotNull(callback);

        C.AchievementManager_FetchAll(mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK,
            InternalFetchAllCallback,
            Callbacks.ToIntPtr<FetchAllResponse>(callback, FetchAllResponse.FromPointer));
    }

    [AOT.MonoPInvokeCallback(typeof(C.FetchAllCallback))]
    private static void InternalFetchAllCallback(IntPtr response, IntPtr data) {
        Callbacks.PerformInternalCallback("AchievementManager#InternalFetchAllCallback",
            Callbacks.Type.Temporary, response, data);
    }

    internal void Increment(string achievementId, uint numSteps) {
        Misc.CheckNotNull(achievementId);

        C.AchievementManager_Increment(mServices.AsHandle(), achievementId, numSteps);
    }

    internal void Reveal(string achievementId) {
        Misc.CheckNotNull(achievementId);

        C.AchievementManager_Reveal(mServices.AsHandle(), achievementId);
    }

    internal void Unlock(string achievementId) {
        Misc.CheckNotNull(achievementId);

        C.AchievementManager_Unlock(mServices.AsHandle(), achievementId);
    }

    internal class FetchAllResponse : BaseReferenceHolder, IEnumerable<NativeAchievement> {

        internal FetchAllResponse (IntPtr selfPointer) : base(selfPointer) {
        }

        internal CommonErrorStatus.ResponseStatus Status() {
            return C.AchievementManager_FetchAllResponse_GetStatus(SelfPtr());
        }

        private UIntPtr Length() {
            return C.AchievementManager_FetchAllResponse_GetData_Length(SelfPtr());
        }

        private NativeAchievement GetElement(UIntPtr index) {
            if (index.ToUInt64() >= Length().ToUInt64()) {
                throw new ArgumentOutOfRangeException();
            }

            return new NativeAchievement(
                C.AchievementManager_FetchAllResponse_GetData_GetElement(SelfPtr(), index));
        }

        public IEnumerator<NativeAchievement> GetEnumerator() {
            return PInvokeUtilities.ToEnumerator(
                C.AchievementManager_FetchAllResponse_GetData_Length(SelfPtr()),
                (index) => GetElement(index));
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        protected override void CallDispose(HandleRef selfPointer) {
            C.AchievementManager_FetchAllResponse_Dispose(selfPointer);
        }

        internal static FetchAllResponse FromPointer(IntPtr pointer) {
            if (pointer.Equals(IntPtr.Zero)) {
                return null;
            }

            return new FetchAllResponse(pointer);
        }
    }
}
}


#endif
