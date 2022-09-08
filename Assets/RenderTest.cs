using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTest : MonoBehaviour
{
    private void Update()
    {
       
        Debug.Log(RendererExtensions.IsVisibleFrom(GetComponent<RectTransform>(), Camera.main));
    }
    
}
