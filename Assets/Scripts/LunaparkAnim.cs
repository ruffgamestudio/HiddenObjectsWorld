using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LunaparkAnim : MonoBehaviour
{
    private Animator _animator;

    private int _animatorNumber;
    private void Awake()
    {
      _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animator.SetInteger("Lunapark", AnimatorIntValues());
    }
    private int AnimatorIntValues()
    {
        switch (gameObject.name)
        {

            case "Gondol":
                _animatorNumber = 0;
                break;

            case "Balloon":
                _animatorNumber = 1;
                break;

            case "Flag":
                _animatorNumber = 2;
                break;

            case "Woman5":
                _animatorNumber = 3;
                break;
        }
        return _animatorNumber;
    }

}
