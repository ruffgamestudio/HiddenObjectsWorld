using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class TapAndCollectItems : MonoBehaviour, IPointerDownHandler
{

    private Camera _camera;
    [SerializeField] private TextMeshProUGUI _popUpItems;

    private TargetUI targetUI;

    private int totalCount;

    private void Awake()
    {
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
            Debug.Log("yeyyyy");
        }
        gameObject.SetActive(false);
    }


}
   
  


