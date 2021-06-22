/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;

namespace GooglePlayGames.BasicApi {
public class Achievement {
    public string Id = "";
    public bool IsIncremental = false;
    public bool IsRevealed = false;
    public bool IsUnlocked = false;
    public int CurrentSteps = 0;
    public int TotalSteps = 0;
    public string Description = "";
    public string Name = "";

    public override string ToString() {
        return string.Format("[Achievement] id={0}, name={1}, desc={2}, type={3}, " +
        " revealed={4}, unlocked={5}, steps={6}/{7}", Id, Name,
            Description, IsIncremental ? "INCREMENTAL" : "STANDARD",
            IsRevealed, IsUnlocked, CurrentSteps, TotalSteps);
    }

    public Achievement() {
    }
}
}

