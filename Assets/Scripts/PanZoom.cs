using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PanZoom : MonoBehaviour
{
    private Vector3 _touchStart, _direction;

    private Camera _camera;

    [SerializeField]
    private float _cameraSpeed;
    private float _zoomOutMin = 2;
    private float _zoomOutMax = 5;
    private float _mapMinX, _mapMaxX, _mapMinY, _mapMaxY;
    private float _minXValue = -7.85f;
    public float maxXValue = 2.35f;
    private float _minYValue = -5.88f;
    private float _maxYValue = 6.88f;

    [SerializeField]
    private SpriteRenderer _cityBG;

    public bool crossCheck;
    public bool isMouseOverUI;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        _mapMinX = _minXValue;
        _mapMaxX = maxXValue;
        _mapMinY = _minYValue;
        _mapMaxY = _maxYValue;
        Move();
    }
    void Move()
    {
        if (!isMouseOverUI)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchStart = _camera.ScreenToWorldPoint(Input.mousePosition);
                crossCheck = false;
            }
            else if (Input.GetMouseButton(0))
            {
                _direction = _touchStart - _camera.ScreenToWorldPoint(Input.mousePosition);
                _direction.z = 0;
                transform.DOMove(ClampCamera(_camera.transform.position + _direction), .25f);
                if (_direction.magnitude > .005f)
                {
                    crossCheck = true;
                }
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                Zoom(difference * .005f);
            }
        }
       
    }

    void Zoom(float increment)
    {
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize,Mathf.Clamp(_camera.orthographicSize - increment, _zoomOutMin, _zoomOutMax),.05f);
        _camera.transform.position = ClampCamera(_camera.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPos)
    {
        float camHeight = _camera.orthographicSize;
        float camWidht = _camera.orthographicSize * _camera.aspect;

        float minX = _mapMinX + camWidht;
        float maxX = _mapMaxX - camWidht;
        float minY = _mapMinY + camHeight;
        float maxY = _mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPos.x, minX, maxX);
        float newY = Mathf.Clamp(targetPos.y, minY, maxY);

        return new Vector3(newX, newY, targetPos.z);
    }


}
