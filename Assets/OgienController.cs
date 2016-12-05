using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class OgienController : MonoBehaviour {

    public GameObject FlameThrower;
    public GameObject PoOgien;

    private GameObject paliOgien;
    public GameObject shapeObject;
    public GameObject CelObject;

    public Text scoreValue;

    private float timeLeft = 0.5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            paliOgien = Instantiate(FlameThrower);
            paliOgien.transform.parent = shapeObject.gameObject.transform;
            paliOgien.transform.position = shapeObject.gameObject.transform.position;
            paliOgien.transform.rotation = shapeObject.gameObject.transform.rotation;
        }

        if (Input.GetMouseButton(0))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                kindleFire();
                timeLeft = 0.5f;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            var script = paliOgien.GetComponent<DigitalRuby.PyroParticles.FireBaseScript>();
            script.Stop();
        }
    }

    void kindleFire()
    {
        var pos = CelObject.transform.position;
        pos.y = pos.y - 1.0f;
        Instantiate(PoOgien, pos, new Quaternion());
        
        //updating score
        int x = 0;
        Int32.TryParse(scoreValue.text, out x);
        x++;
        scoreValue.text = x.ToString();
    }
}
