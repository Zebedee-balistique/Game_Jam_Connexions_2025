using System.Collections.Generic;
using JetBrains.Annotations;
using PooledScrollList.Controller;
using PooledScrollList.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Example
{
    public class PooledDataProviderExample : PooledDataProvider
    {
        public PooledScrollRectBase ScrollRectController;
        public List<Sprite> symbols_sprites;

        public override List<PooledData> GetData()
        {
            var data = new List<PooledData>(symbols_sprites.Count);

            data.Add(new PooledDataExample { sprite = symbols_sprites[symbols_sprites.Count-1] });

            for (var i = 0; i < symbols_sprites.Count; i++)
            {
                data.Add(new PooledDataExample { sprite = symbols_sprites[i] });
            }

            data.Add(new PooledDataExample { sprite = symbols_sprites[0] });

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
}