using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class WorldToUI : MonoBehaviour
{

    public static Action<Transform,RectTransform> JumpToUI;

    private void OnEnable()
    {
        JumpToUI +=JumpToUIPriv;
    }
    private void OnDisable()
    {
        JumpToUI -= JumpToUIPriv;


    }


    public void JumpToUIPriv(Transform currentObject,RectTransform targetUI)
    {
        // transform.DOJump(targetUIObject.transform.position, 5, 1, .5f).OnComplete(()=> targetUIObject.DOScale(targetUIObject.lossyScale + new Vector3(.6f, .6f, .6f),0.2f).SetLoops(2,LoopType.Yoyo));
        currentObject.DOScale(currentObject.lossyScale + new Vector3((currentObject.lossyScale.x * 30) / 100, (currentObject.lossyScale.y * 30) / 100, (currentObject.lossyScale.z * 30) / 100), .2f).SetEase(Ease.OutQuad);
        currentObject.DOMoveY(currentObject.position.y + .9f, 0.2f).SetEase(Ease.OutQuad).OnComplete(() => currentObject.DOMove(targetUI.transform.position, .45f).SetEase(Ease.InQuad).OnComplete(() => {
            currentObject.GetComponent<SpriteRenderer>().enabled = false;
            targetUI.DOScale(targetUI.lossyScale + new Vector3(.8f, .8f, .8f), 0.15f).SetLoops(2, LoopType.Yoyo);
            
        }));
        
    }
    
}
