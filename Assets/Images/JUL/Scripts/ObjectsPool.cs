using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    private List<GameObject> _pool = new List<GameObject>();

    private List<ParticleSystem> _poolEffect = new List<ParticleSystem>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialize(ParticleSystem effect)
    {
        for (int i = 0; i < _capacity; i++)
        {
            ParticleSystem spawned = Instantiate(effect, _container.transform);
            spawned.Stop();
            _poolEffect.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected bool TryGetObject(out ParticleSystem result)
    {
        result = _poolEffect.FirstOrDefault(p => p.isStopped == true);
        return result != null;
    }
}
