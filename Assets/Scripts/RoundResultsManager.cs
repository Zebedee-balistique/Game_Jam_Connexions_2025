using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundResultsManager : Singleton<RoundResultsManager>
{
    public List<WeaponRoundResult> Results { get { return Results; } set 
        {
            Results = value;
            roundResultsPooled.data_list = Results;
        } }

    public int oldScore { get { return oldScore; } set 
        {
            oldScore = value;
            oldScoreTXT.text = value.ToString();
        } }

    public int scoreObtained { get { return scoreObtained; } set 
        {
            scoreObtained = value;
            scoreObtainedTXT.text = value.ToString();
        } }

    public int totalScore { get { return totalScore; } set 
        {
            totalScore = value;
            totalScoreTXT.text = value.ToString();
        } }

    [SerializeField] private TextMeshProUGUI oldScoreTXT;

    [Space]
    [SerializeField] private TextMeshProUGUI plusTXT;

    [Space]
    [SerializeField] private TextMeshProUGUI scoreObtainedTXT;

    [Space]
    [SerializeField] private TextMeshProUGUI equalsTXT;

    [Space]
    [SerializeField] private TextMeshProUGUI totalScoreTXT;

    [Space]
    [SerializeField] private TextMeshProUGUI ptsTXT;

    [Space]
    [SerializeField] private GameObject endGameBTN;
    [SerializeField] private GameObject continueBTN;

    [Space]
    [SerializeField] private RoundResultsPooled roundResultsPooled;

    private bool endGame = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        oldScoreTXT.gameObject.SetActive(false);
        plusTXT.gameObject.SetActive(false);
        scoreObtainedTXT.gameObject.SetActive(false);
        equalsTXT.gameObject.SetActive(false);
        totalScoreTXT.gameObject.SetActive(false);

        endGameBTN.SetActive(false);
        continueBTN.SetActive(false);
        roundResultsPooled.Apply();
        StartCoroutine(Anim());
    }

    private void OnDisable()
    {
        if (endGame)
        {
            PageNavManager.Instance.LoadAdditivePage(4);
        }
        else
        {
            PageNavManager.Instance.LoadAdditivePage(2);
        }
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSecondsRealtime(1f);
        oldScoreTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        plusTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        scoreObtainedTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        equalsTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        totalScoreTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        ptsTXT.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        if (endGame)
        {
            endGameBTN.SetActive(true);
        }
        else
        {
            continueBTN.SetActive(true);
        }
    }

    public void Leave(bool end)
    {
        endGame = end;
        PageNavManager.Instance.UnloadAdditivePage(3);
    }
}
