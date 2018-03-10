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
}
