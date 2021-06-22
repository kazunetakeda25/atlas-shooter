/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using GooglePlayGames.OurUtils;


#if (UNITY_ANDROID || UNITY_IPHONE)
using System;
using System.Runtime.InteropServices;
using System.Text;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.BasicApi.Multiplayer;
using Types = GooglePlayGames.Native.Cwrapper.Types;

using C = GooglePlayGames.Native.Cwrapper.SnapshotMetadataChange;
using B = GooglePlayGames.Native.Cwrapper.SnapshotMetadataChangeBuilder;

namespace GooglePlayGames.Native {
internal class NativeSnapshotMetadataChange : BaseReferenceHolder {
    internal NativeSnapshotMetadataChange(IntPtr selfPointer) : base(selfPointer) {
    }


    protected override void CallDispose(HandleRef selfPointer) {
        C.SnapshotMetadataChange_Dispose(selfPointer);
    }


    internal static NativeSnapshotMetadataChange FromPointer(IntPtr pointer) {
        if (pointer.Equals(IntPtr.Zero)) {
            return null;
        }

        return new NativeSnapshotMetadataChange(pointer);
    }

    internal class Builder : BaseReferenceHolder {
        internal Builder() : base(B.SnapshotMetadataChange_Builder_Construct()) {
        }

        protected override void CallDispose(HandleRef selfPointer) {
            B.SnapshotMetadataChange_Builder_Dispose(selfPointer);
        }

        internal Builder SetDescription(string description) {
            B.SnapshotMetadataChange_Builder_SetDescription(SelfPtr(), description);
            return this;
        }

        internal Builder SetPlayedTime(ulong playedTime) {
            B.SnapshotMetadataChange_Builder_SetPlayedTime(SelfPtr(), playedTime);
            return this;
        }

        internal Builder SetCoverImageFromPngData(byte[] pngData) {
            Misc.CheckNotNull(pngData);
            B.SnapshotMetadataChange_Builder_SetCoverImageFromPngData(SelfPtr(),
                pngData, new UIntPtr((ulong) pngData.LongLength));
            return this;
        }

        internal NativeSnapshotMetadataChange Build() {
            return FromPointer(B.SnapshotMetadataChange_Builder_Create(SelfPtr()));
        }
    }
}
}

#endif // (UNITY_ANDROID || UNITY_IPHONE)
