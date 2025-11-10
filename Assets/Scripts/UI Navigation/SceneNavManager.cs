using NUnit;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ENavigationScene
{
    None,
    MainMenu,
    MainGame,
}

/// <summary>
/// Singleton class
/// </summary>
public class SceneNavManager : Singleton<SceneNavManager>
{
    #region Public Fields

    public CanvasGroup canvasGroup;
    public float duration;

    #endregion

    #region Private Fields



    #endregion

    #region MonoBehaviour Callbacks

    public override void Awake()
    {
        base.Awake();
        if (canvasGroup == null) return;

        StartCoroutine(EnterAnimation());
    }

    #endregion

    #region Public Methods

    public void LoadScene(ENavigationScene sceneID)
    {
        StartCoroutine(LeaveAnimation(sceneID));
    }

    #endregion

    #region Private Methods

    private IEnumerator EnterAnimation()
    {
        if (canvasGroup != null)
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.alpha = 1f;

            var time = Time.time;

            while (Time.time - time < duration)
            {
                canvasGroup.alpha = 1 - ((Time.time - time) / duration);
                yield return null;
            }

            canvasGroup.alpha = 0f;
            canvasGroup.gameObject.SetActive(false);
        }
    }

    private IEnumerator LeaveAnimation(ENavigationScene sceneID)
    {
        if (canvasGroup != null)
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.alpha = 0f;

            var time = Time.time;

            while (Time.time - time < duration)
            {
                canvasGroup.alpha = (Time.time - time) / duration;
                yield return null;
            }

            canvasGroup.alpha = 1f;
            SceneManager.LoadScene((int) sceneID);
        }
    }

    #endregion
}
