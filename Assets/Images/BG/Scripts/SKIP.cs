using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SKIP : MonoBehaviour
{
    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void Skip()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
