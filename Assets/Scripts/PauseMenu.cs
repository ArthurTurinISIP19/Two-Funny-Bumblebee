using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _diePause;

    public void Pause()
    {
        SoundManager.Donk();
        _HUD.SetActive(false);
        _pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void DiePause()
    {
        _HUD.SetActive(false);
        _diePause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Menu()
    {
        SoundManager.Donk();
        SceneManager.LoadScene("StartMenu");
    }
    public void RestartScene()
    {
        SoundManager.Donk();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UnPause()
    {
        SoundManager.Donk();
        _HUD.SetActive(true);
        _pause.SetActive(false);
        Time.timeScale = 1;
    }
}
