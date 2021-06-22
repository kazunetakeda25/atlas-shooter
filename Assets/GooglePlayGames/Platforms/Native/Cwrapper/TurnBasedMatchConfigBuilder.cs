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
internal static class TurnBasedMatchConfigBuilder {
    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_PopulateFromPlayerSelectUIResponse(
        HandleRef self,
         /* from(TurnBasedMultiplayerManager_PlayerSelectUIResponse_t) */ IntPtr response);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_SetVariant(
        HandleRef self,
         /* from(uint32_t) */ uint variant);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_AddPlayerToInvite(
        HandleRef self,
         /* from(char const *) */ string player_id);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(TurnBasedMatchConfig_Builder_t) */ IntPtr TurnBasedMatchConfig_Builder_Construct();

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_SetExclusiveBitMask(
        HandleRef self,
         /* from(uint64_t) */ ulong exclusive_bit_mask);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_SetMaximumAutomatchingPlayers(
        HandleRef self,
         /* from(uint32_t) */ uint maximum_automatching_players);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(TurnBasedMatchConfig_t) */ IntPtr TurnBasedMatchConfig_Builder_Create(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_SetMinimumAutomatchingPlayers(
        HandleRef self,
         /* from(uint32_t) */ uint minimum_automatching_players);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void TurnBasedMatchConfig_Builder_Dispose(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
