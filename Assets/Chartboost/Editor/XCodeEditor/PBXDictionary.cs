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
using System.Collections.Generic;

namespace UnityEditor.XCodeEditorChartboost
{
	public class PBXDictionary : Dictionary<string, object>
	{
		
		public void Append( PBXDictionary dictionary )
		{
			foreach( var item in dictionary) {
				this.Add( item.Key, item.Value );
			}
		}
		
		public void Append<T>( PBXDictionary<T> dictionary ) where T : PBXObject
		{
			foreach( var item in dictionary) {
				this.Add( item.Key, item.Value );
			}
		}

		// This is method hiding and should not be used lightly.
		// Dictionary is sealed and thus cannot be overridden; we hide the base Add() in this class.
		// If you plan to inherit or cast this class be wary.
		public new void Add( string newKey, object newValue )
		{
			if(!this.ContainsKey(newKey))
			{
				base.Add( newKey, newValue );
			}
			else
			{
				this[newKey] = newValue;
			}
		}
	}
	
	public class PBXDictionary<T> : Dictionary<string, T> where T : PBXObject
	{
		public PBXDictionary()
		{
			
		}
		
		public PBXDictionary( PBXDictionary genericDictionary )
		{
			foreach( KeyValuePair<string, object> currentItem in genericDictionary ) {
				if( ((string)((PBXDictionary)currentItem.Value)[ "isa" ]).CompareTo( typeof(T).Name ) == 0 ) {
					T instance = (T)System.Activator.CreateInstance( typeof(T), currentItem.Key, (PBXDictionary)currentItem.Value );
					this.Add( currentItem.Key, instance );
				}
			}	
		}
		
		public void Add( T newObject )
		{
			if(!this.ContainsKey(newObject.guid))
			{
				this.Add( newObject.guid, newObject );
			}
			else
			{
				this[newObject.guid] = newObject;
			}
		}
		
		public void Append( PBXDictionary<T> dictionary )
		{
			foreach( KeyValuePair<string, T> item in dictionary) {
				this.Add( item.Key, (T)item.Value );
			}
		}
		
	}
}
