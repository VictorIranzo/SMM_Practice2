using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoresLoader : MonoBehaviour {

    public GameObject scoreCardPrefab;
    public GameObject scoreContainer;

    public Image backImage;
    public Sprite back_Cave;
    public Sprite back_Forest;

    // Use this for initialization
    void Start () {
        string selectedSkin = DataController.GetSkin();
        if (selectedSkin == "rocks") backImage.sprite = back_Cave;
        else backImage.sprite = back_Forest;

        List<Score> scoresList = DataController.ReadScores().scores;

        scoresList = scoresList.OrderByDescending(n=> n.score).Take(20).ToList();

        foreach (Score score in scoresList)
        {
           GameObject scorePanel = Instantiate(scoreCardPrefab, scoreContainer.transform);
            ScoreScript scoreScript = scorePanel.GetComponent<ScoreScript>();

            scoreScript.user.text = score.user;
            scoreScript.date.text = score.dateTime.ToShortDateString();
            scoreScript.score.text = score.score.ToString();
        }
    }

    public void GoToMenu() {
            SceneManager.LoadScene("Menu2D");
    }
}
