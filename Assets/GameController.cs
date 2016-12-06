using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        if (PlayerPrefs.HasKey("saved"))
        {
            scoreText.text = PlayerPrefs.GetString("score");
            PlayerPrefs.DeleteAll();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel(0);
        }

        if (Input.GetButtonDown("Save"))
        {
            PlayerPrefs.SetInt("saved", 1);
            PlayerPrefs.SetString("score", scoreText.text);
            Debug.Log("Game saved");
        }
	}
}
