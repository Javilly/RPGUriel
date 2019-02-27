using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitGame()
    {
        print("Salíste del juego");
        Application.Quit();
    }
}
