/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine;
using System.Collections.Generic;

namespace GooglePlayGames.OurUtils {
public static class Misc {
    public static bool BuffersAreIdentical(byte[] a, byte[] b) {
        if (a == b) {
            // not only identical but the very same!
            return true;
        }
        if (a == null || b == null) {
            // one of them is null, the other one isn't
            return false;
        }
        if (a.Length != b.Length) {
            return false;
        }
        for(int i = 0; i < a.Length; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }

    public static byte[] GetSubsetBytes(byte[] array, int offset, int length) {
        if (array == null) {
            throw new ArgumentNullException("array");
        }

        if (offset < 0 || offset >= array.Length) {
            throw new ArgumentOutOfRangeException("offset");
        }

        if (length < 0 || (array.Length - offset) < length) {
            throw new ArgumentOutOfRangeException("length");
        }

        if (offset == 0 && length == array.Length) {
            return array;
        }

        byte[] piece = new byte[length];
        Array.Copy(array, offset, piece, 0, length);
        return piece;
    }

    public static T CheckNotNull<T>(T value) {
        if (value == null) {
            throw new ArgumentNullException();
        }

        return value;
    }
}
}

