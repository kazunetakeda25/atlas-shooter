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
internal static class SnapshotManager {
    internal delegate void FetchAllCallback(
         /* from(SnapshotManager_FetchAllResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void OpenCallback(
         /* from(SnapshotManager_OpenResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void CommitCallback(
         /* from(SnapshotManager_CommitResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void ReadCallback(
         /* from(SnapshotManager_ReadResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void SnapshotSelectUICallback(
         /* from(SnapshotManager_SnapshotSelectUIResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_FetchAll(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(SnapshotManager_FetchAllCallback_t) */ FetchAllCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_ShowSelectUIOperation(
        HandleRef self,
        [MarshalAs(UnmanagedType.I1)] /* from(bool) */ bool allow_create,
        [MarshalAs(UnmanagedType.I1)] /* from(bool) */ bool allow_delete,
         /* from(uint32_t) */ uint max_snapshots,
         /* from(char const *) */ string title,
         /* from(SnapshotManager_SnapshotSelectUICallback_t) */ SnapshotSelectUICallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_Read(
        HandleRef self,
         /* from(SnapshotMetadata_t) */ IntPtr snapshot_metadata,
         /* from(SnapshotManager_ReadCallback_t) */ ReadCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_Commit(
        HandleRef self,
         /* from(SnapshotMetadata_t) */ IntPtr snapshot_metadata,
         /* from(SnapshotMetadataChange_t) */ IntPtr metadata_change,
         /* from(uint8_t const *) */ byte[] data,
         /* from(size_t) */ UIntPtr data_size,
         /* from(SnapshotManager_CommitCallback_t) */ CommitCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_Open(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(char const *) */ string file_name,
         /* from(SnapshotConflictPolicy_t) */ Types.SnapshotConflictPolicy conflict_policy,
         /* from(SnapshotManager_OpenCallback_t) */ OpenCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_ResolveConflict(
        HandleRef self,
         /* from(SnapshotMetadata_t) */ IntPtr snapshot_metadata,
         /* from(SnapshotMetadataChange_t) */ IntPtr metadata_change,
         /* from(char const *) */ string conflict_id,
         /* from(SnapshotManager_CommitCallback_t) */ CommitCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_Delete(
        HandleRef self,
         /* from(SnapshotMetadata_t) */ IntPtr snapshot_metadata);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_FetchAllResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus SnapshotManager_FetchAllResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr SnapshotManager_FetchAllResponse_GetData_Length(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_FetchAllResponse_GetData_GetElement(
        HandleRef self,
         /* from(size_t) */ UIntPtr index);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_OpenResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotOpenStatus_t) */ CommonErrorStatus.SnapshotOpenStatus SnapshotManager_OpenResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_OpenResponse_GetData(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr SnapshotManager_OpenResponse_GetConflictId(
        HandleRef self,
         /* from(char *) */ StringBuilder out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_OpenResponse_GetConflictOriginal(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_OpenResponse_GetConflictUnmerged(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_CommitResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus SnapshotManager_CommitResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_CommitResponse_GetData(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_ReadResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus SnapshotManager_ReadResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr SnapshotManager_ReadResponse_GetData(
        HandleRef self,
        [In, Out] /* from(uint8_t *) */ byte[] out_arg,
         /* from(size_t) */ UIntPtr out_size);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void SnapshotManager_SnapshotSelectUIResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(UIStatus_t) */ CommonErrorStatus.UIStatus SnapshotManager_SnapshotSelectUIResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(SnapshotMetadata_t) */ IntPtr SnapshotManager_SnapshotSelectUIResponse_GetData(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
