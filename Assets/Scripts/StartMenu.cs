using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _levelMenu;
    [SerializeField] private GameObject _thxAuthors;

    [SerializeField] private Image _lock1;
    [SerializeField] private Image _lock2;


    private void Start()
    {
        if(PlayerPrefs.GetString("level2") != "open")
        {
            _lock1.gameObject.SetActive(true);
            PlayerPrefs.SetString("level2", "close");
        }
        if (PlayerPrefs.GetString("level3") != "open")
        {
            _lock2.gameObject.SetActive(true);
            PlayerPrefs.SetString("level3", "close");
        }
        if (PlayerPrefs.GetString("level2") == "open")
        {
            _lock1.gameObject.SetActive(false);
            PlayerPrefs.SetString("level2", "open");
        }
        if (PlayerPrefs.GetString("level3") == "open")
        {
            _lock2.gameObject.SetActive(false);
            PlayerPrefs.SetString("level3", "open");
        }
        Time.timeScale = 1;
    }
    public void LevelMenu()
    {
        SoundManager.Donk();
        _buttons.SetActive(false);
        _levelMenu.SetActive(true);
    }
    public void ThxAuthors()
    {
        SoundManager.Donk();
        _buttons.SetActive(false);
        _thxAuthors.SetActive(true);
    }
    public void CloseLevelAuthorsMenu()
    {
        SoundManager.Donk();

        if (_levelMenu.activeSelf == true)
        {
            _levelMenu.SetActive(false);
        }
        if (_thxAuthors.activeSelf == true)
        {
            _thxAuthors.SetActive(false);
        }
        _buttons.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
