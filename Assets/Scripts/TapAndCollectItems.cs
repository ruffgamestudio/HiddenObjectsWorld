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
        switch (gameObject.name)
        {
            case "Donatello":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.donatelloCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Man":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.manCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "PizzaSlice":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.pizzaSliceCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Michi":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.michiCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Sunflower":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.sunflowerCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Crate":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.crateCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Leonardo":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.leonardoCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Raphael":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.raphaelCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Pizza":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.pizzaCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Splinter":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.splinterCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Taco":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.tacoCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Helmet":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.helmetCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
            case "Hamburger":
                GameManager.Instance.totalItemCount++;
                GameManager.Instance.hamburgerCount++;
                gameObject.SetActive(false);
                _popUpItems.SetActive(true);
                break;
        }

    }


    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    SendRayToSelectObjects();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    for (int i = 0; i < _popUpItems.Length; i++)
        //    {
        //        if (_popUpItems[i].activeInHierarchy)
        //        {
        //            _popUpItems[i].SetActive(false);
        //        }
        //    }
        //}
    }


    //void SendRayToSelectObjects()
    //{
    //    StartCoroutine(nameof(DeactivateItems));
    //}

    //IEnumerator DeactivateItems()
    //{
    //    Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
    //    mouseWorldPos.z = 0;
    //    RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
    //    if (hit.collider != null)
    //    {
    //        switch (hit.collider.name)
    //        {
    //            case "Donatello":
    //                print("donatello");
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.donatelloCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Man":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.manCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "PizzaSlice":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.pizzaSliceCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Michi":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.michiCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Sunflower":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.sunflowerCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Crate":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.crateCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Leonardo":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.leonardoCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Raphael":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.raphaelCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Pizza":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.pizzaCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Splinter":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.splinterCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Taco":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.tacoCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Helmet":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.helmetCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //            case "Hamburger":
    //                GameManager.Instance.totalItemCount++;
    //                GameManager.Instance.hamburgerCount++;
    //                hit.collider.GetComponent<SpriteRenderer>().enabled = false;
    //                yield return new WaitForSeconds(.01f);
    //                hit.collider.gameObject.SetActive(false);
    //                break;
    //        }
    //    }
    //}

}
