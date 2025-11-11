
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Basic Class
/// </summary>
public class ReadyGoPage : APage
{
    #region Public Fields

    [SerializeField] private TextMeshProUGUI go_3;
    [SerializeField] private TextMeshProUGUI go_2;
    [SerializeField] private TextMeshProUGUI go_1;
    [SerializeField] private TextMeshProUGUI go_GO;

    #endregion

    #region Private Fields



    #endregion

    private void OnEnable()
    {
        go_GO.gameObject.SetActive(false);
        StartCoroutine(CountdownAnim());
    }

    private void OnDisable()
    {
        //[TODO] : Start the game for real
        Debug.Log("REPLACE THIS BY STARTIGN THE GAME !");
    }

    #region Public Methods



    #endregion

    #region Private Methods

    private IEnumerator CountdownAnim()
    {
        yield return new WaitForSeconds(0.5f);

        go_3.gameObject.SetActive(true);
        go_3.color = new Color(go_3.color.r, go_3.color.g, go_3.color.b, 0);
        go_3.fontSize = 100;

        //popping in the 3
        var time = Time.time;

        while (Time.time - time < 0.25f)
        {
            go_3.color = new Color(go_3.color.r, go_3.color.g, go_3.color.b, (Time.time - time) / 0.25f);
            go_3.fontSize = ((Time.time - time) / 0.25f) * 262.9f + 100;
            yield return null;
        }

        go_3.fontSize = 362.9f;
        go_3.color = new Color(go_3.color.r, go_3.color.g, go_3.color.b, 1);
        yield return new WaitForSeconds(0.4f);

        //popping out the 3
        time = Time.time;

        while (Time.time - time < 0.1f)
        {
            go_3.color = new Color(go_3.color.r, go_3.color.g, go_3.color.b, 1 - ((Time.time - time) / 0.1f));
            go_3.fontSize = (1 - ((Time.time - time) / 0.1f)) * 262.9f + 100;
            yield return null;
        }

        go_3.color = new Color(go_3.color.r, go_3.color.g, go_3.color.b, 0);
        go_3.fontSize = 100;
        go_3.gameObject.SetActive(false);



        //popping in the 2
        go_2.gameObject.SetActive(true);
        go_2.fontSize = 100;
        time = Time.time;

        while (Time.time - time < 0.25f)
        {
            go_2.color = new Color(go_2.color.r, go_2.color.g, go_2.color.b, (Time.time - time) / 0.25f);
            go_2.fontSize = ((Time.time - time) / 0.25f) * 262.9f + 100;
            yield return null;
        }

        go_2.fontSize = 362.9f;
        go_2.color = new Color(go_2.color.r, go_2.color.g, go_2.color.b, 1);
        yield return new WaitForSeconds(0.4f);

        //popping out the 2
        time = Time.time;

        while (Time.time - time < 0.1f)
        {
            go_2.color = new Color(go_2.color.r, go_2.color.g, go_2.color.b, 1 - ((Time.time - time) / 0.1f));
            go_2.fontSize = (1 - ((Time.time - time) / 0.1f)) * 262.9f + 100;
            yield return null;
        }

        go_2.color = new Color(go_2.color.r, go_2.color.g, go_2.color.b, 0);
        go_2.fontSize = 100;
        go_2.gameObject.SetActive(false);



        //popping in the 1
        go_1.gameObject.SetActive(true);
        go_1.fontSize = 100;
        time = Time.time;

        while (Time.time - time < 0.25f)
        {
            go_1.color = new Color(go_1.color.r, go_1.color.g, go_1.color.b, (Time.time - time) / 0.25f);
            go_1.fontSize = ((Time.time - time) / 0.25f) * 262.9f + 100;
            yield return null;
        }

        go_1.fontSize = 362.9f;
        go_1.color = new Color(go_1.color.r, go_1.color.g, go_1.color.b, 1);
        yield return new WaitForSeconds(0.4f);

        //popping out the 1
        time = Time.time;

        while (Time.time - time < 0.1f)
        {
            go_1.color = new Color(go_1.color.r, go_1.color.g, go_1.color.b, 1 - ((Time.time - time) / 0.1f));
            go_1.fontSize = (1 - ((Time.time - time) / 0.1f)) * 262.9f + 100;
            yield return null;
        }

        go_1.color = new Color(go_1.color.r, go_1.color.g, go_1.color.b, 0);
        go_1.fontSize = 100;
        go_1.gameObject.SetActive(false);



        //popping in the GO
        go_GO.gameObject.SetActive(true);
        go_GO.fontSize = 100;
        time = Time.time;

        while (Time.time - time < 0.25f)
        {
            go_GO.color = new Color(go_GO.color.r, go_GO.color.g, go_GO.color.b, (Time.time - time) / 0.25f);
            go_GO.fontSize = ((Time.time - time) / 0.25f) * 262.9f + 100;
            yield return null;
        }

        go_GO.color = new Color(go_GO.color.r, go_GO.color.g, go_GO.color.b, 1);
        yield return new WaitForSeconds(0.5f);

        PageNavManager.Instance.UnloadAdditivePage(2);
    }

    #endregion
}
