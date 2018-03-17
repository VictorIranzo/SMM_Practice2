using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public InputField userName;

    public UnityEngine.UI.Button girlPlayer;
    public UnityEngine.UI.Button boyPlayer;

    public Sprite girlSelected;
    public Sprite girlUnselected;

    public Sprite boySelected;
    public Sprite boyUnselected;

    private Image girlImage;
    private Image boyImage;

    public UnityEngine.UI.Button rockButton;
    public UnityEngine.UI.Button forestButton;

    private Image rockImage;
    private Image forestImage;

    public Sprite rockSelected;
    public Sprite rockUnselected;

    public Sprite forestSelected;
    public Sprite forestUnselected;

    public Image backImage;
    public Sprite back_Cave;
    public Sprite back_Forest;

    private string selectedCharacter;
    private string selectedSkin;

	// Use this for initialization
	void Start () {
        girlImage = girlPlayer.GetComponent<Image>();
        boyImage = boyPlayer.GetComponent<Image>();

        rockImage = rockButton.GetComponent<Image>();
        forestImage = forestButton.GetComponent<Image>();

        userName.text = DataController.GetUser();

        selectedCharacter = DataController.GetCharacter();
        if (selectedCharacter == "girl") girlButtonClick();
        else boyButtonClick();

        selectedSkin = DataController.GetSkin();
        if (selectedSkin == "rocks") rockButtonClick();
        else forestButtonClick();
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

    public void forestButtonClick()
    {
        selectedSkin = "forest";
        forestImage.sprite = forestSelected;
        rockImage.sprite = rockUnselected;
        backImage.sprite = back_Forest;
    }

    public void rockButtonClick()
    {
        selectedSkin = "rocks";
        rockImage.sprite = rockSelected;
        forestImage.sprite = forestUnselected;
        backImage.sprite = back_Cave;
    }

    public void onBackClick() {
        if (userName.text == "") userName.text = "user";
        DataController.SetUser(userName.text);
        DataController.SetCharacter(selectedCharacter);
        DataController.SetSkin(selectedSkin);

        SceneManager.LoadScene("Menu2D");
    }
}
