﻿using UnityEngine;
using System.Collections;

namespace Completed
{	
	public class Loader : MonoBehaviour 
	{
		public GameObject gameManager;			//GameManager prefab to instantiate.
		public GameObject soundManager;			//SoundManager prefab to instantiate.
		
		
		void Awake ()
		{
            string selectedCharacter = DataController.GetCharacter();

            if (selectedCharacter == "girl")
            {
                GameObject boyPlayer = GameObject.Find("Player");
                Destroy(boyPlayer);
            }
            else
            {
                GameObject girlPlayer = GameObject.Find("Player_Girl");
                Destroy(girlPlayer);
            }

            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
            if (GameManager.instance == null)
				
				//Instantiate gameManager prefab
				Instantiate(gameManager);
			
			//Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
			if (SoundManager.instance == null)
				
				//Instantiate SoundManager prefab
				Instantiate(soundManager);
		}
	}
}