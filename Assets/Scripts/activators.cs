using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class activators : MonoBehaviour
{
    [SerializeField] private int _number;
    [SerializeField] private BG_loader _bgLoader;

    private bool _passed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _bgLoader.ActiveBg(_number, _passed);
            _passed = true;
        }
    }
}
