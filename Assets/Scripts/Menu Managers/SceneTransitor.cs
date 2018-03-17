using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour {

    public void GoToPlay() {
        SceneManager.LoadScene("Main");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu2D");
        GameManager.instance.gameEnd = true;
    }
}
