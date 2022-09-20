using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackAnimation : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GetComponent<RayCastAndFireForEnemy>().attack += PlayAttackAnimation;
    }
    private void OnDisable()
    {
        GetComponent<RayCastAndFireForEnemy>().attack -= PlayAttackAnimation;
    }

    private void PlayAttackAnimation()
    {
        _animator.Play("Spider_Attack");
    }
}
