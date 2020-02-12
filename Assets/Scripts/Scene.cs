using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //public LoadSceneMode loadMode = LoadSceneMode.Single;

    // pindah scene ke menu
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    // pindah scene kellading
    public void LoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    // keluar dari game
    public void KeluarScene()
    {
        Application.Quit();
    }

    // pindah scene kellading
    public void GamePlayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.kenney.nl/");
    }
}
