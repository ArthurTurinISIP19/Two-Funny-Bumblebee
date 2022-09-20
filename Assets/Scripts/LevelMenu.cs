using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Level1()
    {
        SoundManager.Donk();
        SceneManager.LoadScene("SampleScene");
    }
    public void Level2()
    {
        if(PlayerPrefs.GetString("level2") == "open")
        {
            SoundManager.Donk();
            SceneManager.LoadScene("Level_2");
        }
    }
    public void Level3()
    {
        if (PlayerPrefs.GetString("level3") == "open")
        {
            SoundManager.Donk();
            SceneManager.LoadScene("Level_3_Boss");
        }
    }
}
