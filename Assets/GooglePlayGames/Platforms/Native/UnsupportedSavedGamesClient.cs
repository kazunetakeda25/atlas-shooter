/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if (UNITY_ANDROID || UNITY_IPHONE)
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;

namespace GooglePlayGames.Native {
internal class UnsupportedSavedGamesClient : ISavedGameClient {

    private readonly string mMessage;

    public UnsupportedSavedGamesClient(string message) {
        this.mMessage = Misc.CheckNotNull(message);
    }

    public void OpenWithAutomaticConflictResolution(string filename, DataSource source,
        ConflictResolutionStrategy resolutionStrategy,
        Action<SavedGameRequestStatus, ISavedGameMetadata> callback) {
        throw new NotImplementedException(mMessage);
    }

    public void OpenWithManualConflictResolution(string filename, DataSource source,
        bool prefetchDataOnConflict, ConflictCallback conflictCallback,
        Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback) {
        throw new NotImplementedException(mMessage);
    }

    public void ReadBinaryData(ISavedGameMetadata metadata,
        Action<SavedGameRequestStatus, byte[]> completedCallback) {
        throw new NotImplementedException(mMessage);
    }

    public void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames,
        bool showCreateSaveUI, bool showDeleteSaveUI, Action<SelectUIStatus, ISavedGameMetadata> callback) {
        throw new NotImplementedException(mMessage);
    }

    public void CommitUpdate(ISavedGameMetadata metadata, SavedGameMetadataUpdate updateForMetadata,
        byte[] updatedBinaryData, Action<SavedGameRequestStatus, ISavedGameMetadata> callback) {
        throw new NotImplementedException(mMessage);
    }

    public void FetchAllSavedGames(DataSource source, Action<SavedGameRequestStatus,
        List<ISavedGameMetadata>> callback) {
        throw new NotImplementedException(mMessage);
    }
}
}
#endif
