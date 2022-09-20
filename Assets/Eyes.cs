using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void FixedUpdate()
    {
        if(_player.transform.position.x <= -255)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(-0.2f, transform.localPosition.y), 0.05f);
        }
        else if (_player.transform.position.x >= -215)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(0.2f, transform.localPosition.y), 0.05f);
        }
        else
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(0, transform.localPosition.y), 0.05f);

        }
    }
}
