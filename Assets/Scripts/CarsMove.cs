using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarsMove : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = transform.position;
    }
    private void Start()
    {
        Move();
    }

    void Move()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(_destination.position, 20));
        mySequence.AppendCallback(() => gameObject.SetActive(false));
        mySequence.Append(transform.DOMove(_startPos, 1));
        mySequence.AppendCallback(() => gameObject.SetActive(true));
        mySequence.Append(transform.DOMove(_destination.position, 20));
        mySequence.SetLoops(-1);
    }
}
