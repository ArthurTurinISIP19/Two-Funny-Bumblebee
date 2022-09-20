using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private trap _trap;

    private int _currentTarget;
    private bool _moveDown = true;


    private void OnEnable()
    {
        _trap.TrapPassed += SpeedOn;
    }
    private void OnDisable()
    {
        _trap.TrapPassed -= SpeedOn;
    }
    private void SpeedOn()
    {
        _speed = 3f;
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed);

        if (transform.position == _positions[_currentTarget])
        {
            if (_currentTarget == 0)
            {
                _currentTarget = 1;
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveDown = true;
            }
            else if (_currentTarget == 1)
            {
                _currentTarget = 0;
                transform.eulerAngles = new Vector3(0, 0, 180);
                _moveDown = false;
            }
        }
    }
}
