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

namespace GooglePlayGames.OurUtils {
public class Logger {
    static bool debugLogEnabled = false;

    public static bool DebugLogEnabled {
        get {
            return debugLogEnabled;
        }
        set {
            debugLogEnabled = value;
        }
    }

    private static bool warningLogEnabled = true;

    public static bool WarningLogEnabled {
        get {
            return warningLogEnabled;
        }
        set {
            warningLogEnabled = value;
        }
    }

    public static void d(string msg) {
        if (debugLogEnabled) {
            Debug.Log(ToLogMessage("", "DEBUG", msg));
        }
    }

    public static void w(string msg) {
        if (warningLogEnabled) {
            Debug.LogWarning(ToLogMessage("!!!", "WARNING", msg));
        }
    }

    public static void e(string msg) {
        if (warningLogEnabled) {
            Debug.LogWarning(ToLogMessage("***", "ERROR", msg));
        }
    }

    public static string describe(byte[] b) {
        return b == null ? "(null)" : "byte[" + b.Length + "]";
    }

    private static string ToLogMessage(String prefix, String logType, String msg) {
        return String.Format("{0} [Play Games Plugin DLL] {1} {2}: {3}",
            prefix, DateTime.Now.ToString("MM/dd/yy H:mm:ss zzz"), logType, msg);
    }
}
}

