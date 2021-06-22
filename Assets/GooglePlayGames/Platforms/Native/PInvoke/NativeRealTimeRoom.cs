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

using C = GooglePlayGames.Native.Cwrapper.RealTimeRoom;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class NativeRealTimeRoom : BaseReferenceHolder {

    internal NativeRealTimeRoom(IntPtr selfPointer) : base(selfPointer) {
    }

    internal string Id() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.RealTimeRoom_Id(SelfPtr(), out_string, size));
    }

    internal IEnumerable<MultiplayerParticipant> Participants() {
        return PInvokeUtilities.ToEnumerable(
            C.RealTimeRoom_Participants_Length(SelfPtr()),
            (index) => new MultiplayerParticipant(
                C.RealTimeRoom_Participants_GetElement(SelfPtr(), index)));
    }

    internal uint ParticipantCount() {
        return C.RealTimeRoom_Participants_Length(SelfPtr()).ToUInt32();
    }

    internal Types.RealTimeRoomStatus Status() {
        return C.RealTimeRoom_Status(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.RealTimeRoom_Dispose(selfPointer);
    }

    internal static NativeRealTimeRoom FromPointer(IntPtr selfPointer) {
        if (selfPointer.Equals(IntPtr.Zero)) {
            return null;
        }

        return new NativeRealTimeRoom(selfPointer);
    }
}
}

#endif
