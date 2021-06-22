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
using GooglePlayGames.OurUtils;

using C = GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration;

namespace GooglePlayGames.Native.PInvoke {

sealed class IosPlatformConfiguration : PlatformConfiguration {

    private IosPlatformConfiguration (IntPtr selfPointer) : base(selfPointer) {
    }

    internal void SetClientId(string clientId) {
        Misc.CheckNotNull(clientId);

        C.IosPlatformConfiguration_SetClientID(SelfPtr(), clientId);
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.IosPlatformConfiguration_Dispose(selfPointer);
    }

    internal static IosPlatformConfiguration Create() {
        return new IosPlatformConfiguration(C.IosPlatformConfiguration_Construct());
    }
}
}


#endif
