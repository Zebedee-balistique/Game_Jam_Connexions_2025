using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public int lifeCount { get { return lifeCount; } set 
        {
            lifeCount = value;
            switch(lifeCount)
            {
                case 0:
                    life1.SetActive(false);
                    life2.SetActive(false);
                    life3.SetActive(false);
                    break;
                case 1:
                    life2.SetActive(false);
                    life3.SetActive(false);
                    break;
                case 2:
                    life3.SetActive(false);
                    break;
                case 3:
                    life1.SetActive(true);
                    life2.SetActive(true);
                    life3.SetActive(true);
                    break;
            }
        } }

    public int roundCount { get { return roundCount; } set 
        {
            roundCount = value;
            roundCountTXT.text = roundCount.ToString();
        } }

    public int totalScore { get { return totalScore; } set 
        {
            totalScore = value;
            totalScoreTXT.text = totalScore.ToString();
        } }

    public int weaponsLeft { get { return weaponsLeft; } set 
        {
            weaponsLeft = value;
            if(weaponsLeft > 1)
            {
                weaponsLeftTXT.text = $"{weaponsLeft.ToString()} weapons left";
            }
            else
            {
                weaponsLeftTXT.text = $"{weaponsLeft.ToString()} weapon left";
            }
            
        } }

    public Sprite weaponToForgeSprite { get { return weaponToForgeSprite; } set 
        {
            weaponToForgeSprite = value;
            weaponToForgeSpriteIMG.sprite = weaponToForgeSprite;
        } }

    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    [Space]

    [SerializeField] private TextMeshProUGUI roundCountTXT;
    [SerializeField] private TextMeshProUGUI totalScoreTXT;
    [SerializeField] private TextMeshProUGUI weaponsLeftTXT;
    [SerializeField] private Image weaponToForgeSpriteIMG;

    public override void Awake()
    {
        base.Awake();
        HideGUI();
    }

    public void HideGUI()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowGUI()
    {
        this.gameObject.SetActive(true);
    }
}
