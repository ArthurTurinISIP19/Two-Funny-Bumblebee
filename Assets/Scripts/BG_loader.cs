using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_loader : MonoBehaviour
{
    [SerializeField] private GameObject[] _bg;    

    public void ActiveBg(int BgNum, bool _passed)
    {
        if(_passed == false)
        {
            _bg[BgNum - 1].gameObject.SetActive(true);
            _bg[BgNum - 3].gameObject.SetActive(false);
        }
        if(_passed == true)
        {
            _bg[BgNum - 3].gameObject.SetActive(true);
        }
    }
}
