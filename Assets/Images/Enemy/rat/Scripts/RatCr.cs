using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCr : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _speedActivator = 0;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private trap _trap;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isSoundPlayed;

    private  AudioSource audioSrc;
    public   AudioClip saw;
    private Animator _animator;

    private int _currentTarget;

    private void Start()
    {
        if (gameObject.tag == "Saw")
        {
            audioSrc = GetComponent<AudioSource>();
            saw = Resources.Load<AudioClip>("Saw");
            Saw(true);
        }
        _animator = GetComponent<Animator>();
    }
    public  void Saw(bool switcher)
    {
        if (switcher == true)
        {
            audioSrc.PlayOneShot(saw, 0.1f);
        }
        else
        {
            audioSrc.Stop();
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);

        if (transform.position == _positions[_currentTarget])
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
            _isGrounded = true;
            _animator.SetInteger("State", 1);
            _speedActivator = 1f;
        }
    }
}
