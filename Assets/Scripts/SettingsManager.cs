using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public UnityEngine.UI.Button girlPlayer;
    public UnityEngine.UI.Button boyPlayer;

    public Sprite girlSelected;
    public Sprite girlUnselected;

    public Sprite boySelected;
    public Sprite boyUnselected;

    private Image girlImage;
    private Image boyImage;

    private string selectedCharacter;

	// Use this for initialization
	void Start () {
        girlImage = girlPlayer.GetComponent<Image>();
        boyImage = boyPlayer.GetComponent<Image>();

        selectedCharacter = DataController.GetCharacter();
        if (selectedCharacter == "girl") girlButtonClick();
        else boyButtonClick();
    }

    public void girlButtonClick() {
        selectedCharacter = "girl";
        girlImage.sprite = girlSelected;
        boyImage.sprite = boyUnselected;
    }

    public void boyButtonClick() {
        selectedCharacter = "boy";
        boyImage.sprite = boySelected;
        girlImage.sprite = girlUnselected;
    }

    public void onBackClick() {
        DataController.SetCharacter(selectedCharacter);

        SceneManager.LoadScene("Menu2D");
    }
}
