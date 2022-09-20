using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINISH : MonoBehaviour
{
    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _finish;
    [SerializeField] private int _lvlToOpen;
    public void Finish()
    {
        _HUD.SetActive(false);
        _finish.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == 7)
        {
            CameraMover.StopSound();
            SoundManager.Finish();
            if (_lvlToOpen == 2)
            {
                PlayerPrefs.SetString("level2", "open");
            }
            if (_lvlToOpen == 3)
            {
                PlayerPrefs.SetString("level3", "open");
            }
            Finish();
        }
    }
}
