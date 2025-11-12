using System.Collections;
using TMPro;
using UnityEngine;

public class GameResultsManager : Singleton<GameResultsManager>
{

    public int rounds_completed { get { return rounds_completed; } set 
        {
            rounds_completed = value;
            roundsCompletedTXT.text = value.ToString();
        } }

    public int weapons_forged { get { return weapons_forged; } set 
        {
            weapons_forged = value;
            weaponsForgedTXT.text = value.ToString();
        } }

    public int perfect_weapons { get { return perfect_weapons; } set 
        {
            perfect_weapons = value;
            perfectWeaponsTXT.text = value.ToString();
        } }

    public int total_score { get { return total_score; } set 
        {
            total_score = value;
            totalScoreAmount.text = value.ToString();
        } }

    [HideInInspector]
    public bool isNewHighScore = false;

    [SerializeField] private GameObject roundsCompleted;
    [SerializeField] private TextMeshProUGUI roundsCompletedTXT;

    [Space]
    [SerializeField] private GameObject weaponsForged;
    [SerializeField] private TextMeshProUGUI weaponsForgedTXT;
    [Space]
    [SerializeField] private GameObject perfectWeapons;
    [SerializeField] private TextMeshProUGUI perfectWeaponsTXT;
    [Space]
    [SerializeField] private GameObject totalScore;
    [SerializeField] private TextMeshProUGUI totalScoreAmount;
    [Space]
    [SerializeField] private GameObject newHighScore;
    [Space]
    [SerializeField] private GameObject buttons;

    private bool doWeReplay = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        roundsCompleted.SetActive(false);
        roundsCompletedTXT.gameObject.SetActive(false);
        weaponsForged.SetActive(false);
        weaponsForgedTXT.gameObject.SetActive(false);
        perfectWeapons.SetActive(false);
        perfectWeaponsTXT.gameObject.SetActive(false);
        totalScore.SetActive(false);
        totalScoreAmount.gameObject.SetActive(false);
        newHighScore.SetActive(false);
        buttons.SetActive(false);
        this.GetComponent<CanvasGroup>().alpha = 1.0f;
        StartCoroutine(Anim());
    }

    private void OnDisable()
    {
        if(doWeReplay)
        {
            PageNavManager.Instance.LoadAdditivePage(2);
        }
        else
        {
            PageNavManager.Instance.LoadAdditivePage(0);
        }
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSecondsRealtime(1f);
        roundsCompleted.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        roundsCompletedTXT.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.25f);
        weaponsForged.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        weaponsForgedTXT.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.25f);
        perfectWeapons.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        perfectWeaponsTXT.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.25f);
        totalScore.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        totalScoreAmount.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);
        if (isNewHighScore)
        {
            newHighScore.SetActive(true);
        }
        buttons.SetActive(true);
    }

    public void Leave(bool replay)
    {
        doWeReplay = replay;
        PageNavManager.Instance.UnloadAdditivePage(4);
    }
}
