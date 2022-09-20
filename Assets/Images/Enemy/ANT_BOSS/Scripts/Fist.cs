using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fist : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Ant _ant;
    [SerializeField] private LayerMask _layer;

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private Material _defaultMaterial;

    public event UnityAction OnHpChange;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _defaultMaterial = _sr.material;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layer || collision.gameObject.layer == 8)
        {
            StartCoroutine(VisualDamage());
            OnHpChange?.Invoke();
        }
    }
    IEnumerator VisualDamage()
    {
        for (int i = 0; i < 1; i++)
        {
            _sr.material = _damageMaterial;
            yield return new WaitForSeconds(0.1f);
            _sr.material = _defaultMaterial;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
