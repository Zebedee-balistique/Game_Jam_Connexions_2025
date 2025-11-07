using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Controller
{
    public class PooledScrollRectController : PooledScrollRectBase
    {
        [Space]
        public double scrollSpeed;
        public AnimationCurve movingPattern;
        public bool goingDown;

        private const float baseSpeed = 168;
        private LayoutElement _spaceElement;
        private float timer = 0;

        protected override void Awake()
        {
            base.Awake();

            var layoutGroup = ScrollRect.content.GetComponent<HorizontalOrVerticalLayoutGroup>();
            if (layoutGroup != null)
            {
                LayoutSpacing = layoutGroup.spacing;
                Padding = layoutGroup.padding;
                ElementSize += LayoutSpacing;
            }
            else
            {
                Debug.LogWarning("Failed to get HorizontalOrVerticalLayoutGroup assigned to ScrollRect's content. PooledScrollRectController won't work as expected.");
            }

            _spaceElement = CreateSpaceElement(ScrollRect, 0f);
            _spaceElement.transform.SetParent(ScrollRect.content.transform, false);
        }

        protected override void UpdateContent()
        {
            AdjustContentSize(ElementSize * TotalElementsCount);

            var scrollAreaSize = ExternalViewPort != null ? GetScrollAreaSize(ExternalViewPort) : GetScrollAreaSize(ScrollRect.viewport);
            var elementsVisibleInScrollArea = Mathf.CeilToInt(scrollAreaSize / ElementSize);
            var elementsCulledAbove = Mathf.Clamp(Mathf.FloorToInt(GetScrollRectNormalizedPosition() * (TotalElementsCount - elementsVisibleInScrollArea)), 0,
                Mathf.Clamp(TotalElementsCount - (elementsVisibleInScrollArea + 1), 0, int.MaxValue));

            AdjustSpaceElement(elementsCulledAbove * ElementSize);

            var requiredElementsInList = Mathf.Min(elementsVisibleInScrollArea + 1, TotalElementsCount);

            if (ActiveElements.Count != requiredElementsInList)
            {
                InitializeElements(requiredElementsInList, elementsCulledAbove);
            }
            else if (LastElementsCulledAbove != elementsCulledAbove)
            {
                ReorientElement(elementsCulledAbove > LastElementsCulledAbove ? ReorientMethod.TopToBottom : ReorientMethod.BottomToTop, elementsCulledAbove);
            }

            LastElementsCulledAbove = elementsCulledAbove;
        }

        protected override void AdjustSpaceElement(float size)
        {
            if (size <= 0)
            {
                _spaceElement.ignoreLayout = true;
            }
            else
            {
                _spaceElement.ignoreLayout = false;
                size -= LayoutSpacing;
            }

            if (ScrollRect.vertical)
            {
                _spaceElement.minHeight = size;
            }
            else
            {
                _spaceElement.minWidth = size;
            }

            _spaceElement.transform.SetSiblingIndex(0);
        }

        protected override void ReorientElement(ReorientMethod reorientMethod, int elementsCulledAbove)
        {
            if (ActiveElements.Count <= 1)
            {
                return;
            }

            if (reorientMethod == ReorientMethod.TopToBottom)
            {
                var top = ActiveElements[0];
                ActiveElements.RemoveAt(0);
                ActiveElements.Add(top);

                top.transform.SetSiblingIndex(ActiveElements[ActiveElements.Count - 2].transform.GetSiblingIndex() + 1);
                top.Data = Data[elementsCulledAbove + ActiveElements.Count - 1];
            }
            else
            {
                var bottom = ActiveElements[ActiveElements.Count - 1];
                ActiveElements.RemoveAt(ActiveElements.Count - 1);
                ActiveElements.Insert(0, bottom);

                bottom.transform.SetSiblingIndex(ActiveElements[1].transform.GetSiblingIndex());
                bottom.Data = Data[elementsCulledAbove];
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Destroy(_spaceElement.gameObject);
        }

        // 07.11.2025 : Added for GameJam
        private void Update()
        {
            if (timer >= 1f) timer = 0;

            if (ScrollRect.content.anchoredPosition.y >= ScrollRect.content.sizeDelta.y - 320)
            {
                ScrollRect.content.anchoredPosition = new Vector2(ScrollRect.content.anchoredPosition.x, 64);
            }
            if (ScrollRect.content.anchoredPosition.y <= 0)
            {
                ScrollRect.content.anchoredPosition = new Vector2(ScrollRect.content.anchoredPosition.x, ScrollRect.content.sizeDelta.y - 384);
            }

            if (!goingDown)
            {
                ScrollRect.content.anchoredPosition = new Vector2(ScrollRect.content.anchoredPosition.x, ScrollRect.content.anchoredPosition.y + (Time.deltaTime * baseSpeed * (float)scrollSpeed) * movingPattern.Evaluate(timer) * 2);
            }
            else
            {
                ScrollRect.content.anchoredPosition = new Vector2(ScrollRect.content.anchoredPosition.x, ScrollRect.content.anchoredPosition.y - (Time.deltaTime * baseSpeed * (float)scrollSpeed) * movingPattern.Evaluate(timer) * 2);
            }

            timer += Time.deltaTime;
        }
    }
}