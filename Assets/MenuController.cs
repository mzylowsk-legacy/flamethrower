using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Button loadGameButton;

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
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(1);
    }

    public void LoadGame()
    {
        Application.LoadLevel(1);
    }
}
