using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDownTest : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PanZoom _panZoom;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _panZoom.isMouseOverUI = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _panZoom.isMouseOverUI = true;
    }
}
