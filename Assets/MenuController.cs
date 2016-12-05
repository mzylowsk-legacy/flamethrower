using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuController : MonoBehaviour {

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
        Application.LoadLevel(1);
    }
}
