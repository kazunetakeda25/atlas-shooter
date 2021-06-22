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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GooglePlayGames.Native.Cwrapper {
internal static class RealTimeRoom {
    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(RealTimeRoomStatus_t) */ Types.RealTimeRoomStatus RealTimeRoom_Status(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr RealTimeRoom_Description(
        HandleRef self,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(uint32_t) */ uint RealTimeRoom_Variant(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(uint64_t) */ ulong RealTimeRoom_CreationTime(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr RealTimeRoom_Participants_Length(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(MultiplayerParticipant_t) */ IntPtr RealTimeRoom_Participants_GetElement(
        HandleRef self,
         /* from(size_t) */ UIntPtr index);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool RealTimeRoom_Valid(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(uint32_t) */ uint RealTimeRoom_RemainingAutomatchingSlots(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(uint64_t) */ ulong RealTimeRoom_AutomatchWaitEstimate(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(MultiplayerParticipant_t) */ IntPtr RealTimeRoom_CreatingParticipant(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr RealTimeRoom_Id(
        HandleRef self,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void RealTimeRoom_Dispose(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
