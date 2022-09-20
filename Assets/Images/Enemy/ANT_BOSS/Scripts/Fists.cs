using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Ant _ant;

    private void OnEnable()
    {
        _ant.OnChangeStageOne += ChangeStageOne;

    }
    private void OnDisable()
    {
        _ant.OnChangeStageOne -= ChangeStageOne;

    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void ChangeStageOne(int num)
    {
            _animator.SetInteger("Fist", num);
        if(num == 3)
        {
            gameObject.SetActive(false);
        }
    }


}
