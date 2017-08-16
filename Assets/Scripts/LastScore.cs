using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LastScore : MonoBehaviour {

    public Text _lastScore;

    private int _allScore;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        _lastScore.text = _allScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AllScore(int Sum)
    {
        _allScore = Sum;
    }
}
