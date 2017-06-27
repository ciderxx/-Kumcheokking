using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    private GameObject _pointsO;
    private GameObject _pointsT;

    // Use this for initialization
    void Start () {
        _pointsO = transform.FindChild("bottom").gameObject;
        _pointsT = transform.FindChild("top").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(_pointsO.transform.position);
        Debug.Log(_pointsT.transform.position);
    }
}
