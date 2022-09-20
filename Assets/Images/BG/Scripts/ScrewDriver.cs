using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private trap _trap;
    [SerializeField] private ParticleSystem _endEffect;
    [SerializeField] private float _multiplier = 100;
    [SerializeField] private byte _counterRotation = 0;



    private Vector2 _direction;
    private int _speedActivator = 0;
    private float _startLocalEulerAnglesZ;
    private bool _forCounter = false;

    private void Start()
    {
        _startLocalEulerAnglesZ = gameObject.transform.localEulerAngles.z;
        if (_startLocalEulerAnglesZ == 90)
            _direction = Vector2.left;
        else
            _direction = Vector2.down;
    }
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
        StartCoroutine(Animation());
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * _speed  * _speedActivator);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 6)
        {
            SoundManager.Bang();
            Instantiate(_endEffect, new Vector3(transform.position.x, transform.position.y - 15f, transform.position.z), Quaternion.Euler(-90, 0, 0));
            gameObject.SetActive(false);
        }
    }

    IEnumerator Animation() 
    {
        if(_counterRotation <= 5)
        {
            if (((gameObject.transform.localEulerAngles.z >= _startLocalEulerAnglesZ + 5 && gameObject.transform.localEulerAngles.z <= 350) || 
                (gameObject.transform.localEulerAngles.z <= _startLocalEulerAnglesZ - 5 || (gameObject.transform.localEulerAngles.z <= 355 && gameObject.transform.localEulerAngles.z >= 350))))
            {
                if(_forCounter == false)
                {
                    _forCounter = true;
                    _multiplier *= -1;
                    _counterRotation++;
                }
            }
            else
            {
                _forCounter= false;
            }

            transform.Rotate(0, 0, Time.deltaTime  * _multiplier);
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(Animation());
        }
        else
        {
            _multiplier = 50;
            transform.Rotate(0, 0, Time.deltaTime * _multiplier);

            yield return new WaitForSeconds(0.01f);

            if (gameObject.transform.localEulerAngles.z >= _startLocalEulerAnglesZ)
            {
                gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y, _startLocalEulerAnglesZ);
                _multiplier = 0;
                _speedActivator = 1;
                SoundManager.EnemyFalling();
                StopCoroutine(Animation());
            }
            else
            {
                StartCoroutine(Animation());
            }
        }
    }
}
