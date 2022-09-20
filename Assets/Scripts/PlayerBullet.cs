using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 50f;
    [SerializeField] private ParticleSystem _effect;

    public bool _isDirectionRight;
    private void OnEnable()
    {
        StartCoroutine(DestroyBullet());
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlayerBulletDestroy();
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 3 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            if (Player._isDirectionRight == true)
            {
                Instantiate(_effect, transform.position, Quaternion.Euler(0, 90, 90));
            }
            if (Player._isDirectionRight == false)
            {
                Instantiate(_effect, transform.position, Quaternion.Euler(180, 90, 90));
            }
            gameObject.SetActive(false);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
