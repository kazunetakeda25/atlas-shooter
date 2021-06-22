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
internal static class MultiplayerParticipant {
    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ParticipantStatus_t) */ Types.ParticipantStatus MultiplayerParticipant_Status(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(uint32_t) */ uint MultiplayerParticipant_MatchRank(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool MultiplayerParticipant_IsConnectedToRoom(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr MultiplayerParticipant_DisplayName(
        HandleRef self,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool MultiplayerParticipant_HasPlayer(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr MultiplayerParticipant_AvatarUrl(
        HandleRef self,
         /* from(ImageResolution_t) */ Types.ImageResolution resolution,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(MatchResult_t) */ Types.MatchResult MultiplayerParticipant_MatchResult(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(Player_t) */ IntPtr MultiplayerParticipant_Player(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void MultiplayerParticipant_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool MultiplayerParticipant_Valid(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool MultiplayerParticipant_HasMatchResult(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr MultiplayerParticipant_Id(
        HandleRef self,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
