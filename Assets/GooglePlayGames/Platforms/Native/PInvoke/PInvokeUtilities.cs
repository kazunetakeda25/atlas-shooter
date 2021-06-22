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
using GooglePlayGames.OurUtils;
using System.Collections.Generic;

namespace GooglePlayGames.Native.PInvoke {
static class PInvokeUtilities {

    private static readonly DateTime UnixEpoch =
        DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

    internal static HandleRef CheckNonNull(HandleRef reference) {
        if (IsNull(reference)) {
            throw new System.InvalidOperationException();
        }

        return reference;
    }

    internal static bool IsNull(HandleRef reference) {
        return IsNull(HandleRef.ToIntPtr(reference));
    }

    internal static bool IsNull(IntPtr pointer) {
        return pointer.Equals(IntPtr.Zero);
    }

    internal static DateTime FromMillisSinceUnixEpoch(long millisSinceEpoch) {
        // DateTime in C# uses Gregorian Calendar rather than millis since epoch.
        // We account for this by manually constructing a timestamp for Unix Epoch
        // and incrementing it by the indicated number of milliseconds.
        return UnixEpoch.Add(TimeSpan.FromMilliseconds(millisSinceEpoch));
    }

    internal delegate UIntPtr OutStringMethod(StringBuilder out_string, UIntPtr out_size);

    internal static String OutParamsToString(OutStringMethod outStringMethod) {
        UIntPtr requiredSize = outStringMethod(null, UIntPtr.Zero);
        if (requiredSize.Equals(UIntPtr.Zero)) {
            return null;
        }

        StringBuilder sizedBuilder = new StringBuilder((int)requiredSize.ToUInt32());
        outStringMethod(sizedBuilder, requiredSize);
        return sizedBuilder.ToString();
    }

    internal delegate UIntPtr OutBytesMethod([In, Out] byte[] out_bytes, UIntPtr out_size);

    internal static byte[] OutParamsToBytes(OutBytesMethod outBytesMethod) {
        UIntPtr requiredSize = outBytesMethod(null, UIntPtr.Zero);

        if (requiredSize.Equals(UIntPtr.Zero)) {
            return new byte[0];
        }

        byte[] bytes = new byte[requiredSize.ToUInt64()];
        outBytesMethod(bytes, requiredSize);
        return bytes;
    }

    internal static IEnumerable<T> ToEnumerable<T>(UIntPtr size, Func<UIntPtr, T> getElement) {
        for(ulong i = 0; i < size.ToUInt64(); i++) {
            yield return getElement(new UIntPtr(i));
        }
    }

    internal static IEnumerator<T> ToEnumerator<T>(UIntPtr size, Func<UIntPtr, T> getElement) {
        return ToEnumerable<T>(size, getElement).GetEnumerator();
    }

    internal static UIntPtr ArrayToSizeT<T>(T[] array) {
        if (array == null) {
            return UIntPtr.Zero;
        }

        return new UIntPtr((ulong)array.Length);
    }
}
}


#endif
