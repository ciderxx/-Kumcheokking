using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public GameObject _pointsT;
    public GameObject _pointsB;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(_pointsT.transform.position);
        Debug.Log(_pointsB.transform.position);
    }
}
