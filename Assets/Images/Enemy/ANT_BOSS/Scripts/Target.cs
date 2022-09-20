using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speedActivator;
    [SerializeField] public float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _effectPower;
    [SerializeField] private bool _IsReloaded = true;


    [SerializeField] private AudioClip shoot;
    private AudioSource audioSrc;
    private CircleCollider2D _cc;

    private void OnEnable()
    {
        audioSrc = GetComponent<AudioSource>();
        gameObject.transform.position = new Vector2(-1000, 1000);
        _IsReloaded = true;
        _speedActivator = 1f;
    }
    void Start()
    {
        _cc = GetComponent<CircleCollider2D>();
        _cc.enabled = false;
        _speed = 0.1f;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, _speed * _speedActivator);
        
        if(((transform.position.x <= _player.transform.position.x +2.5f) && (transform.position.x >= _player.transform.position.x -2.5f)) && ((transform.position.y <= _player.transform.position.y +2.5f) && (transform.position.y >= _player.transform.position.y -2.5f)) && _IsReloaded == true)
        {
            _speedActivator = 0f;
            _IsReloaded = false;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.2f);
        audioSrc.PlayOneShot(shoot);
        Instantiate(_effectPower, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
        _cc.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _cc.enabled = false;
        _IsReloaded = true;
        _speedActivator = 1f;
    }
}


