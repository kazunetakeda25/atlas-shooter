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
/// Real time multiplayer listener. This listener will be called to notify you
/// of real-time room events.
/// </summary>
public interface RealTimeMultiplayerListener {
    /// <summary>
    /// Called during room setup to notify of room setup progress.
    /// </summary>
    /// <param name="percent">The room setup progress in percent (0.0 to 100.0).</param>
    void OnRoomSetupProgress(float percent);

    /// <summary>
    /// Notifies that room setup is finished. If <c>success == true</c>, you should
    /// react by starting to play the game; otherwise, show an error screen.
    /// </summary>
    /// <param name="success">Whether setup was successful.</param>
    void OnRoomConnected(bool success);

    /// <summary>
    /// Notifies that the current player has left the room. This may have happened
    /// because you called LeaveRoom, or because an error occurred and the player
    /// was dropped from the room. You should react by stopping your game and
    /// possibly showing an error screen (unless leaving the room was the player's
    /// request, naturally).
    /// </summary>
    void OnLeftRoom();

    /// <summary>
    /// Called when peers connect to the room.
    /// </summary>
    /// <param name="participantIds">Participant identifiers.</param>
    void OnPeersConnected(string[] participantIds);

    /// <summary>
    /// Called when peers disconnect from the room.
    /// </summary>
    /// <param name="participantIds">Participant identifiers.</param>
    void OnPeersDisconnected(string[] participantIds);

    /// <summary>
    /// Called when a real-time message is received.
    /// </summary>
    /// <param name="isReliable">Whether the message was sent as a reliable message or not.</param>
    /// <param name="senderId">Sender identifier.</param>
    /// <param name="data">Data.</param>
    void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data);
}
}
