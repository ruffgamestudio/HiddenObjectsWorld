using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Unity.VisualScripting;

public class SnapToScroll : MonoBehaviour
{
    public static Action<RectTransform> SnapToScrollBar;

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform contentPanel;

    private float defaultElasticity;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        SnapToScrollBar += SnapTo;
    }
    private void OnDisable()
    {
        SnapToScrollBar -= SnapTo;
    }
    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.elasticity = 0;
        Vector2 temp = (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
                - (Vector2)scrollRect.transform.InverseTransformPoint(target.position) + Vector2.right * 80;

        var X = temp.x;

        contentPanel.DOAnchorPos(new Vector2(X, contentPanel.anchoredPosition.y), 0.1f).OnComplete(()=>scrollRect.elasticity=defaultElasticity);







    }
}
