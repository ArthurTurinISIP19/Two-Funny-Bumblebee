using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trap : MonoBehaviour
{
    [SerializeField] private GameObject _trap;

    private Rigidbody2D rb;
    public event UnityAction TrapPassed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            gameObject.SetActive(false);
            if(_trap != null)
                _trap.SetActive(true);
            TrapPassed?.Invoke();
        }
    }
}
