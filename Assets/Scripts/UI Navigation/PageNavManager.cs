using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum ENavPage
{
    None,
    MainMenu,
    MainGame,
    ReadyGo,
    RoundResults,
    GameResults
}

/// <summary>
/// Key/Value pair class with Serializable attribute
/// </summary>
[Serializable]
public class NavPagePair
{
    [PropertySpace(SpaceBefore = 5)]
    [HideLabel]
    public ENavPage Key;

    [PropertySpace(SpaceAfter = 5, SpaceBefore = 2)]
    [HideLabel]
    public APage Value;

    public NavPagePair(ENavPage key, APage value)
    {
        Key = key;
        Value = value;
    }
}

/// <summary>
/// In-scene page navigation manager
/// </summary>
public class PageNavManager : Singleton<PageNavManager>
{
    #region Public Fields

    /// <summary>
    /// This scene's <see cref="ENavigationScene"/> index.
    /// </summary>
    [SerializeField]
    [LabelText("This Scene's Enum Index")]
    [ValidateInput("@sceneIndex != ENavigationScene.None", "Scene index mustn't be \"None\"", InfoMessageType.Warning)]
    public ENavigationScene sceneIndex = ENavigationScene.None;

    /// <summary>
    /// List of this scene's pages.
    /// </summary>
    [Space]
    [HideLabel]
    [SerializeField]
    public List<NavPagePair> pages = new List<NavPagePair>();

    #endregion

    #region Private Fields



    #endregion

    #region MonoBehaviour Callbacks

    public override void Awake()
    {
        base.Awake();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Loads wanted page
    /// </summary>
    /// <param name="pageID"></param>
    public void LoadAdditivePage(ENavPage pageID)
    {
        //[TODO]
    }

    public void UnloadAdditivePage(ENavPage pageID)
    {
        if (pages != null && pages.Count == 0)
        {
            return;
        }

        //[TODO]
    }

    #endregion

    #region Private Methods



    #endregion
}