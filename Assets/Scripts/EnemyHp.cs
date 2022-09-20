using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private int _hp = 2;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private RatCr _saw;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _hp -= 1;

            if (_hp <= 0)
            {
                Die();
            }
        }
        if(collision.gameObject.layer == 7)
        {
            _hp = 0;
            {   
                Die();
            }
        }
    }

    private void Die()
    {
        if(gameObject.tag == "Saw")
        {
            _saw.Saw(false);
        }
        SoundManager.EnemyDie();
        Instantiate(_dieEffect, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
        gameObject.SetActive(false);
    }
}
