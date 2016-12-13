using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Button loadGameButton;
    public Button highScoresButton;
    public Text highScoresText;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("saved"))
        {
            loadGameButton.enabled = false;
        }
        else
        {
            loadGameButton.enabled = true;
        }
        Cursor.visible = true;
        highScoresButton.gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("saved");
        Application.LoadLevel(1);
    }

    public void LoadGame()
    {
        Application.LoadLevel(1);
    }

    public void ShowHighscores()
    {
        highScoresButton.gameObject.SetActive(true);
        if (PlayerPrefs.HasKey("saved")) {
            highScoresText.text = PlayerPrefs.GetString("highscores");
        }
        else
        {
            highScoresText.text = "No highscores for now";
        }
        
    }
}
