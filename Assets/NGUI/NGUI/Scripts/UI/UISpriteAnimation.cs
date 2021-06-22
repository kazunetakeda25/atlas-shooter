/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Very simple sprite animation. Attach to a sprite and specify a bunch of sprite names and it will cycle through them.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
	[HideInInspector][SerializeField] int mFPS = 30;
	[HideInInspector][SerializeField] string mPrefix = "";
	[HideInInspector][SerializeField] bool mLoop = true;
	protected int loopNumber = 0;
	UISprite mSprite;
	float mDelta = 0f;
	int mIndex = 0;
	bool mActive = true;
	//M.Subhan
	[SerializeField] private bool isPingPong = false;
	private bool goingForward = true;
	List<string> mSpriteNames = new List<string>();

	/// <summary>
	/// Number of frames in the animation.
	/// </summary>

	public int frames { get { return mSpriteNames.Count; } }

	/// <summary>
	/// Animation framerate.
	/// </summary>

	public int framesPerSecond { get { return mFPS; } set { mFPS = value; } }

	/// <summary>
	/// Set the name prefix used to filter sprites from the atlas.
	/// </summary>

	public string namePrefix { get { return mPrefix; } set { if (mPrefix != value) { mPrefix = value; RebuildSpriteList(); } } }

	/// <summary>
	/// Set the animation to be looping or not
	/// </summary>

	public bool loop { get { return mLoop; } set { mLoop = value; } }

	/// <summary>
	/// Returns is the animation is still playing or not
	/// </summary>

	public bool isPlaying { get { return mActive; } }

	/// <summary>
	/// Rebuild the sprite list first thing.
	/// </summary>

	protected void Start () {
		RebuildSpriteList(); 
	}

	/// <summary>
	/// Advance the sprite animation process.
	/// </summary>
	
	public bool IsPingPong {
		get {
			return this.isPingPong;
		}
		set {
			isPingPong = value;
		}
	}
	
	protected  void Update ()
	{
		if (mActive && mSpriteNames.Count > 1 && Application.isPlaying && mFPS > 0f)
		{
			mDelta += Time.deltaTime;
			float rate = 1f / mFPS;

			if (rate < mDelta)
			{
				
				mDelta = (rate > 0f) ? mDelta - rate : 0f;
				
				
					if (++mIndex >= mSpriteNames.Count)
					{
						mIndex = 0;
						mActive = loop;
						this.loopNumber++;
					}
				
				

				if (mActive)
				{
					mSprite.spriteName = mSpriteNames[mIndex];
					mSprite.MakePixelPerfect();
				}
			}
		}
	}

	/// <summary>
	/// Rebuild the sprite list after changing the sprite name.
	/// </summary>

	public void RebuildSpriteList ()
	{
		if (mSprite == null) mSprite = GetComponent<UISprite>();
		mSpriteNames.Clear();

		if (mSprite != null && mSprite.atlas != null)
		{
			List<UIAtlas.Sprite> sprites = mSprite.atlas.spriteList;

			for (int i = 0, imax = sprites.Count; i < imax; ++i)
			{
				UIAtlas.Sprite sprite = sprites[i];

				if (string.IsNullOrEmpty(mPrefix) || sprite.name.StartsWith(mPrefix))
				{
					mSpriteNames.Add(sprite.name);
				}
			}
			mSpriteNames.Sort();
			
			 // if pingpong set, add frames again in reverse
            if(IsPingPong)
            {
				if(mSpriteNames.Count > 2){
	                for (int i = mSpriteNames.Count -2; i >= 1; i--) // skip end frame so we dont double up on it
	                {
	                    mSpriteNames.Add(mSpriteNames[i]);
	                }	
				}		
            }
		}
		
		 
	}
	
	
	public void RebuildSpriteListDesc ()
	{
		if (mSprite == null) mSprite = GetComponent<UISprite>();
		mSpriteNames.Clear();

		if (mSprite != null && mSprite.atlas != null)
		{
			List<UIAtlas.Sprite> sprites = mSprite.atlas.spriteList;

			for (int i = 0, imax = sprites.Count; i < imax; ++i)
			{
				UIAtlas.Sprite sprite = sprites[i];

				if (string.IsNullOrEmpty(mPrefix) || sprite.name.StartsWith(mPrefix))
				{
					mSpriteNames.Add(sprite.name);
				}
			}
			
			mSpriteNames.Sort ( delegate(string a, string b)
								{
									return b.CompareTo (a);		
								});
			
		}
	}
	
	/// <summary>
	/// Reset the animation to frame 0 and activate it.
	/// </summary>

	
	public void Reset()
	{
		mActive = true;
		mIndex = 0;
	}
}
