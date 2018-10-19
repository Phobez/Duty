using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
