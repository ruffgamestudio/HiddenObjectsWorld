using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class TapAndCollectItems : MonoBehaviour, IPointerDownHandler
{

    private Camera _camera;
    [SerializeField] private GameObject _popUpItems;

    private TargetUI targetUI;

    private int totalCount;

    private Vector3 _firstPos;

    private Sprite _sprite;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>().sprite;        
        _firstPos = this.transform.position;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        foreach (var item in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (item.TryGetComponent<RectTransform>(out RectTransform t))
            {
                targetUI = t.GetComponent<TargetUI>();
            }
            else
            {
                totalCount++;
            }

        }
        targetUI.totalCount = totalCount;
        targetUI.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = targetUI.count + "/" + targetUI.totalCount;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!RendererExtensions.IsFullyVisibleFrom(targetUI.GetComponent<RectTransform>(), Camera.main))
        {
            SnapToScroll.SnapToScrollBar(targetUI.GetComponent<RectTransform>());
        }
   
        //if (targetUI.transform.parent.GetSiblingIndex() <= 4)
        //{
        //    GameManager.Instance.contentBar.DOAnchorPosX(1097,0.2f);
        //}
        //else if (targetUI.transform.parent.GetSiblingIndex() > 4&& targetUI.transform.parent.GetSiblingIndex() <= 9)
        //{
        //    GameManager.Instance.contentBar.DOAnchorPosX(307, 0.2f);
        //}
        //else if (targetUI.transform.parent.GetSiblingIndex() > 9 && targetUI.transform.parent.GetSiblingIndex() <= 14)
        //{
        //    GameManager.Instance.contentBar.DOAnchorPosX(-195, 0.2f);
        //}
        GameObject VFX=Instantiate(GameManager.Instance.trailVFX, transform);
        VFX.transform.localPosition = Vector3.zero;
        GameManager.Instance.CollectableClicked(gameObject.tag);
        WorldToUI.JumpToUI(transform, targetUI.GetComponent<RectTransform>());
        
    }

    public void TheMomentBeforeDestroy()
    {
        targetUI.count++;
        targetUI.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = targetUI.count + "/" + targetUI.totalCount;
        //_popUpItems.text = targetUI.count + "/" + targetUI.totalCount;
        int count = GameObject.FindGameObjectsWithTag(gameObject.tag).Length;
        if (count == 2)
        {
            
        }
        gameObject.SetActive(false);
    }

    public void PopUp()
    {
        GameObject obj = Instantiate(_popUpItems);
        GameManager.Instance._popUpItem = obj;
        obj.transform.position = _firstPos+new Vector3(0,.5f,0);
        obj.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _sprite;
        obj.transform.GetChild(1).GetComponent<TextMeshPro>().text = gameObject.tag;
        obj.transform.GetChild(2).GetComponent<TextMeshPro>().text = (targetUI.count+1) + "/" + (targetUI.totalCount);
    }


}
   
  


