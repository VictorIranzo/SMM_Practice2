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

    public void GoToScores()
    {
        SceneManager.LoadScene("Scores");
    }

    public void GoToMenu()
    {
        PointsManager.instance.SaveScore();

        SceneManager.LoadScene("Menu2D");

        GameManager.instance.gameEnd = true;

#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        Screen.orientation = ScreenOrientation.AutoRotation;
#endif
    }

    public void Exit()
    {
        Application.Quit();
    }
}
