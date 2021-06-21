/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using System.Collections.Generic;
using System.IO;

public class GPGSProjectSettings {
    private static GPGSProjectSettings sInstance = null;

    public static GPGSProjectSettings Instance {
        get {
            if (sInstance == null) {
                sInstance = new GPGSProjectSettings();
            }
            return sInstance;
        }
    }

    bool mDirty = false;
    string mFile;
    Dictionary<string, string> mDict = new Dictionary<string, string>();

    private GPGSProjectSettings() {
        string ds = Path.DirectorySeparatorChar.ToString();
        mFile = "Assets/Editor/projsettings.txt".Replace("/", ds);

        if (File.Exists(mFile)) {
            StreamReader rd = new StreamReader(mFile);
            while(!rd.EndOfStream) {
                string line = rd.ReadLine();
                if (line == null || line.Trim().Length == 0) {
                    break;
                }
                line = line.Trim();
                string[] p = line.Split(new char[] { '=' }, 2);
                if (p.Length >= 2) {
                    mDict[p[0].Trim()] = p[1].Trim();
                }
            }
            rd.Close();
        }

    }

    public string Get(string key, string defaultValue) {
        if (mDict.ContainsKey(key)) {
            return mDict[key];
        } else {
            return defaultValue;
        }
    }

    public string Get(string key) {
        return Get(key, "");
    }

    public bool GetBool(string key, bool defaultValue) {
        return Get(key, defaultValue ? "true" : "false").Equals("true");
    }

    public bool GetBool(string key) {
        return Get(key, "false").Equals("true");
    }

    public void Set(string key, string val) {
        mDict[key] = val;
        mDirty = true;
    }

    public void Set(string key, bool val) {
        Set(key, val ? "true" : "false");
    }

    public void Save() {
        if (!mDirty) {
            return;
        }
        StreamWriter wr = new StreamWriter(mFile, false);
        foreach (string key in mDict.Keys) {
            wr.WriteLine(key + "=" + mDict[key]);
        }
        wr.Close();
        mDirty = false;
    }
}

