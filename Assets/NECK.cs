using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NECK : MonoBehaviour
{
    [SerializeField] private Ant _ant;
    [SerializeField] private float _activator;
    private void OnEnable()
    {
        _ant.OnChangeStageOne += ChangeStageOne;

    }
    private void OnDisable()
    {
        _ant.OnChangeStageOne -= ChangeStageOne;

    }

    private void FixedUpdate()
    {
        if(gameObject.transform.eulerAngles.x > 1)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x - _activator, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
        }

    }
    private void ChangeStageOne(int num)
    {
        if (num == 3)
        {
            _activator = 0.2f;
        }
    }
}
