using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cross : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Camera _camera;

    [SerializeField] private GameObject _cross;

    private Animator _crossAnimator;

    private PanZoom _panZoom;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _panZoom = _camera.GetComponent<PanZoom>();
        _crossAnimator = _cross.GetComponent<Animator>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _panZoom.crossCheck = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(CrossCheck(eventData));
    }

    IEnumerator CrossCheck(PointerEventData eventdata)
    {
        if (!_panZoom.crossCheck)
        {
            _cross.transform.position = _camera.ScreenToWorldPoint(eventdata.position) + new Vector3(-0.08f,-0.97f,9);
            _cross.SetActive(true);
            _crossAnimator.SetBool("Cross", true);
            yield return new WaitForSeconds(.3f);
            _crossAnimator.SetBool("Cross", false);
            _cross.SetActive(false);
        }
    }
}
