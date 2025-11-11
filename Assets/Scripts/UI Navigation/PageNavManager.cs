using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum ENavPage
{
    None = -1,
    MainMenu = 0,
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
    /// List of this scene's pages.
    /// </summary>
    [Space]
    [HideLabel]
    [SerializeField]
    public List<NavPagePair> pages = new List<NavPagePair>();

    #endregion

    #region Private Fields

    [SerializeField] private CanvasGroup canvasGroup;

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
    public void LoadAdditivePage(int pageID)
    {
        if (pages != null && pages.Count == 0)
        {
            return;
        }

        StartCoroutine(LoadAdditivePageAnim(pageID));
    }

    public void UnloadAdditivePage(int pageID)
    {
        if (pages != null && pages.Count == 0)
        {
            return;
        }

        StartCoroutine(UnloadAdditivePageAnim(pageID));
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameAnim());
    }

    #endregion

    #region Private Methods

    private IEnumerator LoadAdditivePageAnim(int pageID)
    {
        pages[pageID].Value.gameObject.SetActive(true);
        pages[pageID].Value.canvasGroup.alpha = 0f;

        var time = Time.time;

        while (Time.time - time < 0.5f)
        {
            pages[pageID].Value.canvasGroup.alpha = (Time.time - time) / 0.5f;
            yield return null;
        }

        pages[pageID].Value.canvasGroup.alpha = 1f;
    }

    private IEnumerator UnloadAdditivePageAnim(int pageID)
    {
        pages[pageID].Value.canvasGroup.alpha = 1f;

        var time = Time.time;

        while (Time.time - time < 0.5f)
        {
            pages[pageID].Value.canvasGroup.alpha = 1 - ((Time.time - time) / 0.5f);
            yield return null;
        }

        pages[pageID].Value.canvasGroup.alpha = 0f;
        pages[pageID].Value.gameObject.SetActive(false);
    }

    private IEnumerator ExitGameAnim()
    {
        if(canvasGroup != null)
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.alpha = 0f;

            var time = Time.time;

            while (Time.time - time < 0.5f)
            {
                canvasGroup.alpha = (Time.time - time) / 0.5f;
                yield return null;
            }

            canvasGroup.alpha = 1f;
            Debug.Log("Exitting...");
            Application.Quit();
        }
    }

    #endregion
}