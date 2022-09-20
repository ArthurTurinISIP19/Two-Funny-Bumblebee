using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disk_trap : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private trap _trap;
    [SerializeField] private int _speedActivator = 0;

    private AudioSource audioSrc;
    public AudioClip wheel;
    private Animator _animator;

    private int _currentTarget = 1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _trap.TrapPassed += AnimationOn;
        if (gameObject.tag == "Wheel")
        {
            audioSrc = GetComponent<AudioSource>();
        }
    }
    private void OnDisable()
    {
        _trap.TrapPassed -= AnimationOn;
    }
    private void AnimationOn()
    {
        _animator.SetInteger("State", 1);
        StartCoroutine(WaitForAttack());
        if(gameObject.tag == "Wheel")
        {
        audioSrc.PlayOneShot(wheel);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);
        if(transform.position == _positions[_currentTarget])
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _speedActivator = 1;
    }
}
