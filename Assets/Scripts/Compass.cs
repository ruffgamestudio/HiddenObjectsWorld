using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Compass : MonoBehaviour
{

    [SerializeField] private GameObject _example;
    void Update()
    {
        transform.DOLookAt(_example.transform.position, 1, AxisConstraint.None,Vector3.up);
    }
}
