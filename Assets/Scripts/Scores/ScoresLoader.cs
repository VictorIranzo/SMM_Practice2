using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresLoader : MonoBehaviour {

    public GameObject scoreCardPrefab;
    public GameObject scoreContainer;

	// Use this for initialization
	void Start () {
       List<Score> scoresList = DataController.ReadScores().scores;

        foreach (Score score in scoresList)
        {
           GameObject scorePanel = Instantiate(scoreCardPrefab, scoreContainer.transform);
            ScoreScript scoreScript = scorePanel.GetComponent<ScoreScript>();

            scoreScript.user.text = score.user;
            scoreScript.date.text = score.dateTime.ToShortDateString();
            scoreScript.score.text = score.score.ToString();
        }
    }
}
