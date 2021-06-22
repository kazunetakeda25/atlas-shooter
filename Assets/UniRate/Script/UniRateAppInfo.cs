/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//
//	UniRateAppInfo.cs
//  Created by Wang Wei(@onevcat) on 2013-7-15.
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UniRateAppInfo {
	public bool validAppInfo;

	public string bundleId;
	public int appStoreGenreID;
	public int appID;
	public string version;

	private const string kAppInfoResultsKey = "results";
	private const string kAppInfoBundleIdKey = "bundleId";
	private const string kAppInfoGenreIdKey = "primaryGenreId";
	private const string kAppInfoAppIdKey = "trackId";
	private const string kAppInfoVersion = "version";


	public UniRateAppInfo(string jsonResponse) {
		Dictionary<string, object> response = UniRateMiniJSON.Json.Deserialize(jsonResponse) as Dictionary<string, object>;
		if (response != null) {
			List<object> results = response[kAppInfoResultsKey] as List<object>;
			if (results != null && results.Count > 0) {
				Dictionary<string, object> result = results[0] as Dictionary<string, object>;
				if (result != null) {
					bundleId = result[kAppInfoBundleIdKey] as string;
					appStoreGenreID = Convert.ToInt32(result[kAppInfoGenreIdKey]);
					appID = Convert.ToInt32(result[kAppInfoAppIdKey]);
					version = result[kAppInfoVersion] as string;
					validAppInfo = true;
				}
			}
		}
	}
}
