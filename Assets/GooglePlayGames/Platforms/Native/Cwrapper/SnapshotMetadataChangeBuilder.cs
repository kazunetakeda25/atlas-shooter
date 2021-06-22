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
internal static class SnapshotMetadataChangeBuilder {
    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotMetadataChange_Builder_SetDescription(
        HandleRef self,
         /* from(char const *) */ string description);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadataChange_Builder_t) */ IntPtr SnapshotMetadataChange_Builder_Construct();

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotMetadataChange_Builder_SetPlayedTime(
        HandleRef self,
         /* from(uint64_t) */ ulong played_time);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotMetadataChange_Builder_SetCoverImageFromPngData(
        HandleRef self,
         /* from(uint8_t const *) */ byte[] png_data,
         /* from(size_t) */ UIntPtr png_data_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadataChange_t) */ IntPtr SnapshotMetadataChange_Builder_Create(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotMetadataChange_Builder_Dispose(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
