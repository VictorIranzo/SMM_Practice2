using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
    public Image backImage;
    public Image titleImage;

    public Sprite back_Cave;
    public Sprite back_Forest;

    public Sprite title_Boy_Red;
    public Sprite title_Boy_Orange;

    public Sprite title_Girl_Red;
    public Sprite title_Girl_Orange;

    private void Start()
    {
        string character = DataController.GetCharacter();
        string skin = DataController.GetSkin();

        if (skin == "rocks")
        {
            backImage.sprite = back_Cave;
            if (character == "boy") titleImage.sprite = title_Boy_Orange;
            else titleImage.sprite = title_Girl_Orange;
        }
        else {
            backImage.sprite = back_Forest;
            if (character == "boy") titleImage.sprite = title_Boy_Red;
            else titleImage.sprite = title_Girl_Red;
        }
    }
}
