using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour {

    public int _character;

    private Hunger _hungerScript;
    private Score _scoreScript;
    private Player _playerScript;

    private int _nomami = 1;
    private int _sobooni = 2;
    private int _youtoober = 3;
    private int _nuteom = 4;

    void Awake()
    {
        _hungerScript = GameObject.FindObjectOfType<Hunger>();
        _scoreScript = GameObject.FindObjectOfType<Score>();
        _playerScript = GameObject.FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start () {
        charAttribute();
    }
	
	// Update is called once per frame
	void Update () {
      
	}

    public void charAttribute()
    {
        if(_character == _nomami)
        {
            return;
        }

        else if (_character == _sobooni)
        {
            _hungerScript.Sobooni(0.0025f);
        }

        else if (_character == _youtoober)
        {
            _scoreScript.Youtoober(true);
        }

        else if (_character == _nuteom)
        {
            _playerScript.Nuteom(true);
        }
    }
}
