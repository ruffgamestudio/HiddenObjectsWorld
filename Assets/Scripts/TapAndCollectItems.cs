using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TapAndCollectItems : MonoBehaviour, IPointerDownHandler
{

    private Camera _camera;
    [SerializeField] private GameObject _popUpItems;
    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.CollectableClicked(gameObject.tag);
        gameObject.SetActive(false);
    }

}
   
  


