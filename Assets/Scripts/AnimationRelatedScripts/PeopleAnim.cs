using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAnim : MonoBehaviour
{
    private Animator _animator;

    private int _animatorNumber;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animator.SetInteger("People", AnimatorIntValues());
    }
    private int AnimatorIntValues()
    {
        switch (gameObject.name)
        {
            case "Man2Lunapark":
                _animatorNumber = 0;
                break;

            case "Woman4BackStreetDance":
                _animatorNumber = 1;
                break;
            case "Woman3StreetDance":
                _animatorNumber = 2;
                break;
            case "Man1Lunapark":
                _animatorNumber = 3;
                break;
            case "Man3LunaparkDance":
                _animatorNumber = 4;
                break;

            case "Woman5LunaparkBalloon":
                _animatorNumber = 5;
                break;
        }
        return _animatorNumber;
    }
}
