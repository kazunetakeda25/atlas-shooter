/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if UNITY_ANDROID
using System;
using UnityEngine;
using System.Reflection;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native {
internal static class JavaUtils {

    private static ConstructorInfo IntPtrConstructor =
        typeof(AndroidJavaObject).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            new []{typeof(IntPtr)},
            null);

    /// <summary>
    /// Converts an jobject (represented as an IntPtr) to an AndroidJavaObject by invoking the
    /// hidden IntPtr-taking constructor via reflection. I'm not a fan of bypassing visibility
    /// protection like this, but I haven't found another way of doing it.
    /// </summary>
    /// <returns>An AndroidJavaObject corresponding to the passed pointer.</returns>
    /// <param name="jobject">An IntPtr corresponding to a jobject</param>
    internal static AndroidJavaObject JavaObjectFromPointer(IntPtr jobject) {
        if (jobject == IntPtr.Zero) {
            return null;
        }

        return (AndroidJavaObject) IntPtrConstructor.Invoke(new object[] { jobject });
    }

    /// <summary>
    /// Calls a method on a java object while handling null return values.
    /// Sadly, it appears that calling a method that returns a null Object in Java so we work
    /// around this by catching null pointer exceptions a checking for the word "null".
    /// </summary>
    internal static AndroidJavaObject NullSafeCall(this AndroidJavaObject target,
        string methodName, params object[] args) {
        try {
            return target.Call<AndroidJavaObject>(methodName, args);
        } catch (Exception ex) {
            if (ex.Message.Contains("null")) {
                // expected -- means method returned null
                return null;
            } else {
                Logger.w("CallObjectMethod exception: " + ex);
                return null;
            }
        }
    }

}
}
#endif
