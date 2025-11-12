using System.Collections.Generic;
using JetBrains.Annotations;
using PooledScrollList.Controller;
using PooledScrollList.Data;
using PooledScrollList.Example;
using UnityEngine;

public class RoundResultsPooled : PooledDataProvider
{
    public PooledScrollRectBase ScrollRectController;
    public List<WeaponRoundResult> data_list;

    public override List<PooledData> GetData()
    {
        var data = new List<PooledData>(data_list.Count);

        for (var i = 0; i < data_list.Count; i++)
        {
            data.Add(new RoundPooledData { data = data_list[i] });
        }

        return data;
    }

    [UsedImplicitly]
    public void Apply()
    {
        var data = GetData();

        if (ScrollRectController != null)
        {
            ScrollRectController.Initialize(data);
        }
    }
}
