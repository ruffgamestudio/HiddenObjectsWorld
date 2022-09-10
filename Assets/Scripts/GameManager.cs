using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private TapAndCollectItems _tapAndCollectItems;

    private PanZoom _panZoom;

    private Camera _camera;

    private Animator _panelButtonAnimator;
    private Animator _cloudsAnimator;

   
    public GameObject trailVFX;

    [SerializeField] private Image _down, _up, _progressBar;
    [SerializeField] private Image[] _ticks;

    [SerializeField] private TextMeshProUGUI _progressBarText;
    [SerializeField] private TextMeshProUGUI[] _itemTexts;

    [HideInInspector] public float totalItemCount;
    [HideInInspector] public float donatelloCount;
    [HideInInspector] public float manCount;
    [HideInInspector] public float pizzaSliceCount;
    [HideInInspector] public float michiCount;
    [HideInInspector] public float sunflowerCount;
    [HideInInspector] public float crateCount;
    [HideInInspector] public float leonardoCount;
    [HideInInspector] public float raphaelCount;
    [HideInInspector] public float pizzaCount;
    [HideInInspector] public float splinterCount;
    [HideInInspector] public float tacoCount;
    [HideInInspector] public float helmetCount;
    [HideInInspector] public float hamburgerCount;
    private float _numberOfItems = 19;


    [SerializeField] private Transform[] _itemsParents;
    [SerializeField] private Transform _content;
    [SerializeField] private Transform _cameraCloudPos;

    [SerializeField] private GameObject _newAreaPanel;
    [SerializeField] private GameObject _clouds;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject _magnifyingGlassCirclePrefab;
    private GameObject _circleInstantiated;


   public GameObject _popUpItem;



    private bool _newAreaCheck;


    void Awake()
    {
        Instance = this;
        _panelButtonAnimator = GameObject.FindGameObjectWithTag("ItemPanel").GetComponent<Animator>();
        _tapAndCollectItems = FindObjectOfType<TapAndCollectItems>();
        _panZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PanZoom>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _cloudsAnimator = _clouds.GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           

            if (_circleInstantiated!=null)
            {
                _circleInstantiated.SetActive(false);
            }

            if (_popUpItem!=null)
            {

                ProgressCircle();
                Destroy(_popUpItem);
            }
        }
      
    }

    void ProgressCircle()
    {
        float itemCount = totalItemCount / _numberOfItems;
        _progressBar.fillAmount = itemCount;
        _progressBarText.text = totalItemCount.ToString() + "/" + _numberOfItems;
        if (totalItemCount == _numberOfItems && !_newAreaCheck)
        {
            NextArea();
            _newAreaCheck = true;
        }
    }

    void NextArea()
    {
        _panZoom.maxXValue = 13.66f;
        _numberOfItems = 50;
        _newAreaPanel.SetActive(true);
    }

    public void CloudsAndCameraMove()
    {
        StartCoroutine(nameof(CloudsAndCameraMoveNumerator));
    }
    IEnumerator CloudsAndCameraMoveNumerator()
    {
        _newAreaPanel.SetActive(false);
        _camera.transform.DOMove(_cameraCloudPos.position, 1);
        yield return new WaitForSeconds(1);
        _cloudsAnimator.SetBool("CloudsOpen", true);
        yield return new WaitForSeconds(3.3f);
        _clouds.SetActive(false);
    }

    public void CollectableClicked(string tag)
    {
        switch (tag)
        {
            case "Donatello":
                totalItemCount++;
                donatelloCount++;
                break;
            case "Man":
                totalItemCount++;
                manCount++;
                break;
            case "PizzaSlice":
                totalItemCount++;
                pizzaSliceCount++;
                break;
            case "Michi":
                totalItemCount++;
                michiCount++;
                break;
            case "Sunflower":
                totalItemCount++;
                sunflowerCount++;
                break;
            case "Crate":
                totalItemCount++;
                crateCount++;
                break;
            case "Leonardo":
                totalItemCount++;
                leonardoCount++;
                break;
            case "Raphael":
                totalItemCount++;
                raphaelCount++;
                break;
            case "Pizza":
                totalItemCount++;
                pizzaCount++;
                break;
            case "Splinter":
                totalItemCount++;
                splinterCount++;
                break;
            case "Taco":
                totalItemCount++;
                tacoCount++;
                break;
            case "Helmet":
                totalItemCount++;
                helmetCount++;
                break;
            case "Hamburger":
                totalItemCount++;
                hamburgerCount++;
                break;
        }
    }
    public void ItemPanelButton()
    {
        _panelButtonAnimator.SetTrigger("Down");
        if (_down.enabled)
        {
            _down.enabled = false;
            _up.enabled = true;
        }
        else
        {
            _down.enabled = true;
            _up.enabled = false;
        }
    }

    public void MagnifyingGlassButton()
    {
        int random›tem = Random.Range(0, 19);
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            if (!_items[random›tem].activeInHierarchy)
            {
                random›tem = Random.Range(0, 19);
            }
            else
            {
                break;
            }
        }
        _camera.transform.DOMove(_items[random›tem].transform.position + new Vector3(0, 0, -11), 2);
        _camera.orthographicSize = 2;
        _circleInstantiated = Instantiate(_magnifyingGlassCirclePrefab, _items[random›tem].transform.position,Quaternion.identity);
    }
}
