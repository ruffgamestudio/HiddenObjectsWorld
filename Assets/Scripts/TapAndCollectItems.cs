using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TapAndCollectItems : MonoBehaviour, IPointerDownHandler
{

    private Camera _camera;
    [SerializeField] private GameObject _popUpItems;

    private RectTransform targetUI;
    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        foreach (var item in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (item.TryGetComponent<RectTransform>(out RectTransform t))
            {
                targetUI = t;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject VFX=Instantiate(GameManager.Instance.trailVFX, transform);
        VFX.transform.localPosition = Vector3.zero;
        GameManager.Instance.CollectableClicked(gameObject.tag);
        WorldToUI.JumpToUI(transform, targetUI);
    }

}
   
  


