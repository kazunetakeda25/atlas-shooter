/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using System.IO;
using Json = XMiniJSON;

namespace UnityEditor.XCodeEditorChartboost 
{
	using Debug = UnityEngine.Debug;
	public class XCMod 
	{
//		private string group;
//		private ArrayList patches;
//		private ArrayList libs;
//		private ArrayList frameworks;
//		private ArrayList headerpaths;
//		private ArrayList files;
//		private ArrayList folders;
//		private ArrayList excludes;
		private Hashtable _datastore;
		private ArrayList _libs;
		
		public string name { get; private set; }
		public string path { get; private set; }
		
		public string group {
			get {
				return (string)_datastore["group"];
			}
		}
		
		public ArrayList patches {
			get {
				return (ArrayList)_datastore["patches"];
			}
		}
		
		public ArrayList libs {
			get {
				if( _libs == null ) {
					_libs = new ArrayList( ((ArrayList)_datastore["libs"]).Count );
					foreach( string fileRef in (ArrayList)_datastore["libs"] ) {
						_libs.Add( new XCModFile( fileRef ) );
					}
				}
				return _libs;
			}
		}
		
		public ArrayList frameworks {
			get {
				return (ArrayList)_datastore["frameworks"];
			}
		}
		
		public ArrayList headerpaths {
			get {
				return (ArrayList)_datastore["headerpaths"];
			}
		}

		public Hashtable buildSettings {
			get {
				return (Hashtable)_datastore["buildSettings"];
			}
		}
		
		public ArrayList files {
			get {
				return (ArrayList)_datastore["files"];
			}
		}
		
		public ArrayList folders {
			get {
				return (ArrayList)_datastore["folders"];
			}
		}
		
		public ArrayList excludes {
			get {
				return (ArrayList)_datastore["excludes"];
			}
		}
		
		public XCMod( string filename )
		{	
			FileInfo projectFileInfo = new FileInfo( filename );
			if( !projectFileInfo.Exists ) {
				Debug.LogWarning( "File does not exist." );
			}
			
			name = System.IO.Path.GetFileNameWithoutExtension( filename );
			path = System.IO.Path.GetDirectoryName( filename );
			
			string contents = projectFileInfo.OpenText().ReadToEnd();
			_datastore = (Hashtable)XMiniJSON.jsonDecode( contents );
			
//			group = (string)_datastore["group"];
//			patches = (ArrayList)_datastore["patches"];
//			libs = (ArrayList)_datastore["libs"];
//			frameworks = (ArrayList)_datastore["frameworks"];
//			headerpaths = (ArrayList)_datastore["headerpaths"];
//			files = (ArrayList)_datastore["files"];
//			folders = (ArrayList)_datastore["folders"];
//			excludes = (ArrayList)_datastore["excludes"];
		}
		
			
//	"group": "GameCenter",
//	"patches": [],
//	"libs": [],
//	"frameworks": ["GameKit.framework"],
//	"headerpaths": ["Editor/iOS/GameCenter/**"],					
//	"files":   ["Editor/iOS/GameCenter/GameCenterBinding.m",
//				"Editor/iOS/GameCenter/GameCenterController.h",
//				"Editor/iOS/GameCenter/GameCenterController.mm",
//				"Editor/iOS/GameCenter/GameCenterManager.h",
//				"Editor/iOS/GameCenter/GameCenterManager.m"],
//	"folders": [],	
//	"excludes": ["^.*\\.meta$", "^.*\\.mdown^", "^.*\\.pdf$"]
		
	}
	
	public class XCModFile
	{
		public string filePath { get; private set; }
		public bool isWeak { get; private set; }
		
		public XCModFile( string inputString )
		{
			isWeak = false;
			
			if( inputString.Contains( ":" ) ) {
				string[] parts = inputString.Split( ':' );
				filePath = parts[0];
				isWeak = ( parts[1].CompareTo( "weak" ) == 0 );	
			}
			else {
				filePath = inputString;
			}
		}
	}
}
