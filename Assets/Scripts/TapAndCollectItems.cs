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


