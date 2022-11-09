using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject GameMenu;

    public GameObject DefeatMenu;

    public GameObject VictoryMenu;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void TogglePause(bool value)
    {
        GameMenu?.SetActive(value);
    }

    public void ShowDefeat()
    {
        DefeatMenu?.SetActive(true);
    }

    public void ShowVictory()
    {
        VictoryMenu?.SetActive(true);
    }
}
