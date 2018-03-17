using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Level : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        string selectedCharacter = DataController.GetCharacter();

        if (selectedCharacter == "girl")
        {
            player = GameObject.Find("Player_Girl").transform;
        }
        else
        {
            player = GameObject.Find("Player").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position;
	}
}
