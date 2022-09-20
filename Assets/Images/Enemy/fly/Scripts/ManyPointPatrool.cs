using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ManyPointPatrool : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private float _speedActivator = 0;

    private int _currentTarget = 0;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);

        if (transform.position == _positions[_currentTarget])
        {
            if (_currentTarget == _positions.Length - 1 || _currentTarget == 0)
            {
                transform.Rotate(0, 180, 0);
                Array.Reverse(_positions);
            }
            else
            {
                _currentTarget++;
            }
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
