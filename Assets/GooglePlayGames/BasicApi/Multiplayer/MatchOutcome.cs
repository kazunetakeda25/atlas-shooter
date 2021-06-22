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

namespace GooglePlayGames.BasicApi.Multiplayer {
/// <summary>
/// Represents the outcome of a match (who won, who lost...).
/// </summary>
public class MatchOutcome {
    public enum ParticipantResult {
        Unset = -1,
        None = 0,
        Win = 1,
        Loss = 2,
        Tie = 3
    };

    public const uint PlacementUnset = 0;

    private List<string> mParticipantIds = new List<string>();
    private Dictionary<string, uint> mPlacements = new Dictionary<string, uint>();
    private Dictionary<string, ParticipantResult> mResults =
        new Dictionary<string, ParticipantResult>();

    public MatchOutcome() {
    }

    /// <summary>
    /// Sets the result for a given participant. A result is whether they won,
    /// lost or tied and, optionally, their placement (1st, 2nd, ...).
    /// </summary>
    /// <param name="participantId">Participant identifier.</param>
    /// <param name="result">Result. May be Win, Loss, Tie or None.</param>
    /// <param name="placement">Placement. Use 0 for unset, 1 for 1st, 2 for 2nd, etc.</param>
    public void SetParticipantResult(string participantId, ParticipantResult result,
                                         uint placement) {
        if (!mParticipantIds.Contains(participantId)) {
            mParticipantIds.Add(participantId);
        }
        mPlacements[participantId] = placement;
        mResults[participantId] = result;
    }

    /// <summary>
    /// <see cref="SetParticipantResult(string,ParticipantResult,int)"/>
    /// </summary>
    public void SetParticipantResult(string participantId, ParticipantResult result) {
        SetParticipantResult(participantId, result, PlacementUnset);
    }

    /// <summary>
    /// <see cref="SetParticipantResult(string,ParticipantResult,int)"/>
    /// </summary>
    public void SetParticipantResult(string participantId, uint placement) {
        SetParticipantResult(participantId, ParticipantResult.Unset, placement);
    }

    /// <summary>
    /// Returns a list of the participant IDs in this match outcome.
    /// </summary>
    /// <value>The participant ids.</value>
    public List<string> ParticipantIds {
        get {
            return mParticipantIds;
        }
    }

    /// Returns the result for the given participant ID.
    public ParticipantResult GetResultFor(string participantId) {
        return mResults.ContainsKey(participantId) ? mResults[participantId] :
                    ParticipantResult.Unset;
    }

    /// Returns the placement for the given participant ID.
    public uint GetPlacementFor(string participantId) {
        return mPlacements.ContainsKey(participantId) ? mPlacements[participantId] :
                    PlacementUnset;
    }

    public override string ToString() {
        string s = "[MatchOutcome";
        foreach (string pid in mParticipantIds) {
            s += string.Format(" {0}->({1},{2})", pid,
                GetResultFor(pid), GetPlacementFor(pid));
        }
        return s + "]";
    }

}
}

