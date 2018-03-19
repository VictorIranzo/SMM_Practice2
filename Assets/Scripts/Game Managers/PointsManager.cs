using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {

    private static int points;

    private Player player;

    private Text coinText;

    public static PointsManager instance = null;

	void Awake() {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            points = 0;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        string selectedCharacter = DataController.GetCharacter();

        if (selectedCharacter == "boy")
        {
            GameObject boyPlayer = GameObject.Find("Player");
            player = boyPlayer.GetComponent<Player>();
        }
        else
        {
            GameObject girlPlayer = GameObject.Find("Player_Girl");
            player = girlPlayer.GetComponent<Player>();
        }

        InitCoins();
    }

    private void InitCoins()
    {
        coinText = (Text)GameObject.Find("CoinText").GetComponent<Text>();
        coinText.text = points.ToString();
    }

    public void UpdatePoints() {
        points += CounterScript.counter;
        points += player.food;
    }

    public void SaveScore() {
        DataController.AddScore(points);
    }
}
