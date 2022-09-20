using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Player>()._speed = 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Player>()._speed = 50;
        }
    }
}
