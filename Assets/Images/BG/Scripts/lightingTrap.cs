using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightingTrap : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private trap _trap;
    [SerializeField] private int _speedActivator = 0;

    [SerializeField] private ParticleSystem _startEffect;
    [SerializeField] private ParticleSystem _endEffect;

    private Vector2 _startPosition;
    private int _currentTarget = 1;

    private void Start()
    {
        _startPosition = transform.position;
    }
    private void OnEnable()
    {
        _trap.TrapPassed += AnimationOn;
    }
    private void OnDisable()
    {
        _trap.TrapPassed -= AnimationOn;
    }
    private void AnimationOn()
    {
        SoundManager.Lightning();
        Instantiate(_startEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        StartCoroutine(WaitForAttack());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);
        if (transform.position == _positions[_currentTarget])
        {
            Instantiate(_endEffect, new Vector3(transform.position.x, transform.position.y - 15f, transform.position.z), Quaternion.Euler(-90, 0, 0));
            gameObject.SetActive(false);
        }
    }

 
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _speedActivator = 1;
    }
}
