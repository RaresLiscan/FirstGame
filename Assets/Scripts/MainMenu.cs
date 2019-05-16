using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public Camera mainCamera;
    
    public void Play()
    {
        SceneManager.LoadScene("FirstGame");
    }

    public void Options()
    {
        text.text = "Nu e gata inca";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FOV()
    {
        mainCamera.fieldOfView = slider.value;
    }

}
