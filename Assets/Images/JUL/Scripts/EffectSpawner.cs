using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : ObjectsPool
{
    [SerializeField] private ParticleSystem _effectPrefab;

    private void Start()
    {
        Initialize(_effectPrefab);
    }
    public void Fire()
    {
        if (TryGetObject(out ParticleSystem effect))
        {
            SetBullet(effect);
        }
    }

    private void SetBullet(ParticleSystem bullet)
    {
        bullet.Play();
        bullet.transform.position = gameObject.transform.position;
    }
}
