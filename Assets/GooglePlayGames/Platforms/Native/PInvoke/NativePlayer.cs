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
using System.Runtime.InteropServices;
using System.Text;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.BasicApi.Multiplayer;
using Types = GooglePlayGames.Native.Cwrapper.Types;

using C = GooglePlayGames.Native.Cwrapper.Player;

namespace GooglePlayGames.Native {
internal class NativePlayer : BaseReferenceHolder {

    internal NativePlayer (IntPtr selfPointer) : base(selfPointer) {
    }

    internal string Id() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, out_size) => C.Player_Id(SelfPtr(), out_string, out_size));
    }

    internal string Name() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, out_size) => C.Player_Name(SelfPtr(), out_string, out_size));
    }

    internal string AvatarURL() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, out_size) => C.Player_AvatarUrl(SelfPtr(),
                    Types.ImageResolution.ICON, out_string, out_size));
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.Player_Dispose(selfPointer);
    }

    internal Player AsPlayer() {
        return new Player(Name(), Id(), AvatarURL());
    }
}
}


#endif
