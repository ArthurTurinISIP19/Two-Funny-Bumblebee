using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchor_trap : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected Vector3[] _positions;
    [SerializeField] private trap _trap;

    private int _speedActivator = 0;
    private int _currentTarget = 1;

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
        if(gameObject.tag == "Anchor")
        {
            SoundManager.ShipBell();    
        }
        _speedActivator = 1;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);
        if (transform.position == _positions[_currentTarget])
        {
            if(gameObject.tag == "BrickForReset")
            {
                gameObject.transform.position = _positions[0];
            }
            else
            {
                ActiveOff();
            }
        }
    }

    private void ActiveOff()
    {
        gameObject.SetActive(false);
    }
}
