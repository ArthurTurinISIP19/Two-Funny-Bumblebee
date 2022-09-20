using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCar : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _speedActivator = 0;
    [SerializeField] private GameObject[] _fist;

    [SerializeField] private Ant _ant;


    private Animator _animator;
    private int _currentTarget;

    private void Start()
    {

        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _fist[_currentTarget].transform.position, _speed * _speedActivator);

        if (transform.position == _fist[_currentTarget].transform.position)
        {
            if (_currentTarget == 0)
            {
                _currentTarget = 1;
            }
            else if (_currentTarget == 1)
            {
                _currentTarget = 0;
            }
            transform.Rotate(0, 180, 0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _animator.SetInteger("State", 1);
            _speedActivator = 1f;
        }
    }
}
