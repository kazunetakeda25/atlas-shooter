/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.SavedGame {
/// <summary>
/// Interface representing the metadata for a saved game. These instances are also used as handles
/// for reading and writing the content of the underlying file.
/// </summary>
public interface ISavedGameMetadata {

    /// <summary>
    /// Returns true if this metadata can be used for operations related to raw file data (i.e.
    /// the binary data contained in the underlying file). Metadata returned by Open operations
    /// will be "Open". After an update to the file is committed or the metadata is used to resolve
    /// a conflict, the corresponding Metadata is closed, and IsOpen will return false.
    ///
    /// </summary>
    /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
    bool IsOpen {
        get;
    }

    /// <summary>
    /// Returns the filename for this saved game. A saved game filename will only consist of
    /// non-URL reserved characters (i.e. a-z, A-Z, 0-9, or the symbols "-", ".", "_", or "~")
    /// and will between 1 and 100 characters in length (inclusive).
    /// </summary>
    /// <value>The filename.</value>
    string Filename {
        get;
    }

    /// <summary>
    /// Returns a human-readable description of what the saved game contains. This may be null.
    /// </summary>
    /// <value>The description.</value>
    string Description {
        get;
    }

    /// <summary>
    /// A URL corresponding to the PNG-encoded image corresponding to this saved game. null if
    /// the saved game does not have a cover image.
    /// </summary>
    /// <value>The cover image URL.</value>
    string CoverImageURL {
        get;
    }

    /// <summary>
    /// Returns the total time played by the player for this saved game. This value is
    /// developer-specified and may be tracked in any way that is appropriate to the game. Note
    /// that this value is specific to this specific saved game (unless the developer intentionally
    /// sets the same value on all saved games). If the value was not set, this will be equal to
    /// <code>TimeSpan.FromMilliseconds(0)</code>
    /// </summary>
    /// <value>The total time played.</value>
    TimeSpan TotalTimePlayed {
        get;
    }

    /// <summary>
    /// A timestamp corresponding to the last modification to the underlying saved game. If the
    /// saved game is newly created, this value will correspond to the time the first Open
    /// occurred. Otherwise, this corresponds to time the last successful write occurred (either by
    /// CommitUpdate or Resolve methods).
    /// </summary>
    /// <value>The last modified timestamp.</value>
    DateTime LastModifiedTimestamp {
        get;
    }
}
}

