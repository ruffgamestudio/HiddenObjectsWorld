using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnim : MonoBehaviour
{
    private Animator _animator;

    private int _animatorNumber;
    private void Awake()
    {
     _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animator.SetInteger("Int", AnimatorIntValues());
    }


    private int AnimatorIntValues()
    {
        switch (gameObject.name)
        {

            case "BusYellow(1)":
                _animatorNumber = 0;
                break;

            case "CarRed":
                _animatorNumber = 1;
                break;

            case "BusWhite":
                _animatorNumber = 2;
                break;
        }
        return _animatorNumber;  
    }
}
