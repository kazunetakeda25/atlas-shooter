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

using C = GooglePlayGames.Native.Cwrapper.ParticipantResults;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class ParticipantResults : BaseReferenceHolder {

    internal ParticipantResults(IntPtr selfPointer) : base(selfPointer) {
    }

    internal bool HasResultsForParticipant(string participantId) {
        return C.ParticipantResults_HasResultsForParticipant(SelfPtr(), participantId);
    }

    internal uint PlacingForParticipant(string participantId) {
        return C.ParticipantResults_PlaceForParticipant(SelfPtr(), participantId);
    }

    internal Types.MatchResult ResultsForParticipant(string participantId) {
        return C.ParticipantResults_MatchResultForParticipant(SelfPtr(), participantId);
    }

    internal ParticipantResults WithResult(string participantId, uint placing,
        Types.MatchResult result) {
        return new ParticipantResults(C.ParticipantResults_WithResult(
            SelfPtr(), participantId, placing, result));
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.ParticipantResults_Dispose(selfPointer);
    }
}
}

#endif
