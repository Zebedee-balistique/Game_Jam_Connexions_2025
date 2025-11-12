using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : Singleton<MaskManager>
{
    public Transform Root;
    public Transform Bigparent;
    public Image img;
    public GameObject Blackscreen2;
    public GameObject GUI_;
    public RectTransform rect;

    public override void Awake()
    {
        base.Awake();
        Blackscreen2.SetActive(false);
        GUI_.SetActive(true);
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }
    private void Mask()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        Root.SetParent(this.transform);
    }
    [Button]
    public void Unmask()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        Root.SetParent(Bigparent);
    }

    [Button]
    public void ChangeTarget(Slot slot)
    {
        RectTransform slot_rect = slot.GetComponent<RectTransform>();
        GUIManager.Instance.ShowGUI();
        Unmask();

        //changer position du mask
        rect.sizeDelta = new Vector2(slot_rect.sizeDelta.x, slot_rect.sizeDelta.y + 262.7f);
        rect.position = new Vector2(slot_rect.position.x, rect.position.y);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -428.5f);
        //

        Mask();
        GUIManager.Instance.transform.SetAsLastSibling();
    }

    public IEnumerator BlackScreen(float duration)
    {
        Blackscreen2.SetActive(true);
        Blackscreen2.transform.SetAsLastSibling();
        yield return new WaitForSecondsRealtime(duration);
        Blackscreen2.SetActive(false);
    }
}
