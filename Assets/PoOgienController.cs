using UnityEngine;
using System.Collections;

public class PoOgienController : MonoBehaviour {

    public float Duration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Duration <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

        Duration -= Time.deltaTime * 2;
	}
}
