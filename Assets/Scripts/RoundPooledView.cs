
using System.Collections.Generic;
using PooledScrollList.Data;
using PooledScrollList.View;
using System;
using UnityEngine.UI;
using TMPro;
using PooledScrollList.Example;

/// <summary>
/// Basic Class
/// </summary>

[Serializable]
public class RoundPooledData : PooledData
{
    public WeaponRoundResult data;
}

public class RoundPooledView : PooledView
{
    public Image correct_sprite_IMG;
    public List<Image> weapon_symbols_IMG;
    public TextMeshProUGUI winRatioTXT;
    public Image LostALifeIMG;
    public TextMeshProUGUI pointsAmoun;

    public override void SetData(PooledData data)
    {
        base.SetData(data);

        var exampleData = (RoundPooledData)data;
        correct_sprite_IMG.sprite = exampleData.data.correct_sprite;
        winRatioTXT.text = exampleData.data.win_ratio.ToString();
        LostALifeIMG.enabled = exampleData.data.win_ratio < 0.5f;
        pointsAmoun.text = exampleData.data.score.ToString();
        for(int i = 0; i < 9; i++)
        {
            if(i < exampleData.data.weapon_symbols.Count)
            {
                weapon_symbols_IMG[i].gameObject.SetActive(true);
                weapon_symbols_IMG[i].sprite = exampleData.data.weapon_symbols[i];
            }
            else
            {
                weapon_symbols_IMG[i].gameObject.SetActive(false);
            }
        }
    }
}
