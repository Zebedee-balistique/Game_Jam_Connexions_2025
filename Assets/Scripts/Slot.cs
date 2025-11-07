using System.Collections.Generic;
using PooledScrollList.Controller;
using PooledScrollList.Example;
using UnityEngine;

/// <summary>
/// MonoBehaviour class
/// </summary>
public class Slot : MonoBehaviour
{
    #region Public Fields

    public double scroll_speed { get { return scroll_speed; } set 
        { 
            scroll_speed = value;
            if(pooled_scroll_rect_controller != null)
            {
                pooled_scroll_rect_controller.scrollSpeed = scroll_speed;
            }
            else
            {
                Debug.LogWarning("[Slot] : No pooled_scroll_rect_controller assigned.");
            }
        } }

    public bool going_down { get { return going_down; } set 
        { 
            going_down = value;
            if(pooled_scroll_rect_controller != null)
            {
                pooled_scroll_rect_controller.goingDown = going_down;
            }
            else
            {
                Debug.LogWarning("[Slot] : No pooled_scroll_rect_controller assigned.");
            }
        } }

    public float width { get { return width; } set 
        { 
            width = value;
            //[TODO]
        } }

    [HideInInspector]
    public List<Sprite> symbols_sprites { get { return symbols_sprites; } set 
        {
            symbols_sprites = value;
            if (pooled_data_provider != null)
            {
                pooled_data_provider.symbols_sprites = symbols_sprites;
                pooled_data_provider.Apply();
            }
            else
            {
                Debug.LogWarning("[Slot] : No pooled_data_provider assigned.");
            }
        } }

    public AnimationCurve moving_pattern { get { return moving_pattern; } set 
        {
            moving_pattern = value;
            if(pooled_scroll_rect_controller != null)
            {
                pooled_scroll_rect_controller.movingPattern = moving_pattern;
            }
            else
            {
                Debug.LogWarning("[Slot] : No pooled_scroll_rect_controller assigned.");
            }
        } }

    #endregion

    #region Private Fields

    [SerializeField] private PooledDataProviderExample pooled_data_provider;
    [SerializeField] private PooledScrollRectController pooled_scroll_rect_controller;

    #endregion

    #region MonoBehaviour Callbacks



    #endregion

    #region Public Methods



    #endregion

    #region Private Methods


    #endregion
}
