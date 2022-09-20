using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _object;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            for (int i = 0; i < _object.Length; i++)
            {
                _object[i].SetActive(false);
            }
        }
    }
}
