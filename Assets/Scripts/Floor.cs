using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    GameObject game = null;

    void Guapyo()
    {
        game = transform.FindChild("GameObject").gameObject;

        Debug.Log(game.transform.position);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Guapyo();
	}
}
