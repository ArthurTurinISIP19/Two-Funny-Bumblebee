using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ObjectsPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointRight;
    [SerializeField] private Transform _bulletSpawnPointLeft;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }
    public void Fire()
    {
        if (TryGetObject(out GameObject bullet) && Player._isDirectionRight)
        {
            SetBullet(bullet, _bulletSpawnPointRight.position);
        }
        else
        {
            SetBullet(bullet, _bulletSpawnPointLeft.position);
        }
    }

    private void SetBullet(GameObject bullet, Vector2 bulletSpawnPoint)
    {
        if (GetComponent<Player>() != null)
        {
            if (Player._isDirectionRight == true)
            {
                bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Player._isDirectionRight == false)
            {
                bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = bulletSpawnPoint;
        } 
    }
}
