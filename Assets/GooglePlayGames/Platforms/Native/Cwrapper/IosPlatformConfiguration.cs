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
internal static class IosPlatformConfiguration {
    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(IosPlatformConfiguration_t) */ IntPtr IosPlatformConfiguration_Construct();

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void IosPlatformConfiguration_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool IosPlatformConfiguration_Valid(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void IosPlatformConfiguration_SetClientID(
        HandleRef self,
        /* from(char const *) */ string client_id);
}
}
#endif
