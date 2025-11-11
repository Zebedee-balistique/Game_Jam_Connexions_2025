using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : Singleton<MaskManager>
{
    public Transform Root;
    public Transform Bigparent;
    public Image img;
    public GameObject Blackscreen2;
    public GameObject GUI;
    public RectTransform rect;

    public override void Awake()
    {
        base.Awake();
        Blackscreen2.SetActive(false);
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }
    private void Mask()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        Root.SetParent(this.transform);
    }
    [Button]
    private void Unmask()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        Root.SetParent(Bigparent);
        GUI.transform.SetAsLastSibling();
    }

    [Button]
    public void ChangeTarget(RectTransform slot)
    {
        Blackscreen2.SetActive(true);
        Blackscreen2.transform.SetAsLastSibling();
        GUI.SetActive(true);
        GUI.transform.SetAsLastSibling();
        Unmask();

        //changer position du mask
        rect.sizeDelta = new Vector2(slot.sizeDelta.x, slot.sizeDelta.y + 262.7f);
        rect.position = new Vector2(slot.position.x, rect.position.y);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -428.5f);
        //

        Mask();
        Blackscreen2.SetActive(false);
    }
}
