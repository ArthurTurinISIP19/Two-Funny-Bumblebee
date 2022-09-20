using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFromRayCast : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 50f;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private bool _destroyOnPlayerBullet = false;

    [Header("Fire Directions")]
    [SerializeField] private bool _upFire = false;
    [SerializeField] private bool _downFire = false;
    [SerializeField] private bool _leftFire = false;
    [SerializeField] private bool _rightFire = false;

    [SerializeField] private bool _firstActivation = true;

    private Vector2 _fireDirection;
    private void OnEnable()
    {
        if (gameObject.tag == "nail")
        {
            if (_firstActivation == false)
            {
            SoundManager.EnemyFalling();
            }
            else
            {
                DeActive();
            }
            
        }
        StartCoroutine(TimerDestroyBullet(_timeToDestroy));
    }
    private void DeActive()
    {
        _firstActivation = false;
    }
    private void Start()
    {
       
        if (_upFire)
        {
            _fireDirection = Vector2.up;
        }
        else if (_downFire)
        {
            _fireDirection = Vector2.down;
        }
        else if (_leftFire)
        {
            _fireDirection = Vector2.left;
        }
        else if (_rightFire)
        {
            _fireDirection = Vector2.right;
        }
        _firstActivation = false;
    }
    void FixedUpdate()
    {
        transform.Translate(_fireDirection * _bulletSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 6)
        {
            DestroyBullet();
        }
        if(collision.gameObject.layer == 8 && _destroyOnPlayerBullet == true)
        {
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        SoundManager.Bang();
        Instantiate(_effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    IEnumerator TimerDestroyBullet(float _time)
    {
        yield return new WaitForSeconds(_time);
        
        if (gameObject.activeSelf == true)
        {
            DestroyBullet();
        }
        
    }
}
