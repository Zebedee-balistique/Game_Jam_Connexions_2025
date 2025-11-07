using System;
using PooledScrollList.Data;
using PooledScrollList.View;
using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Example
{
    [Serializable]
    public class PooledDataExample : PooledData
    {
        public Sprite sprite;
    }

    public class PooledViewExample : PooledView
    {
        public Image Image;

        public override void SetData(PooledData data)
        {
            base.SetData(data);

            var exampleData = (PooledDataExample) data;
            Image.sprite = exampleData.sprite;
        }
    }
}