using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public enum FruitScore
    {
        gibon = 5000,
        gumgum = 0,
        kumchuk = 10000,
        masit = 10000,
        aku = 2500,
        ggoRrrrrr = 2500
    }

    public Text _score;

    private int _healthScore = 0;
    private float _sumNumber = 0;

    private bool _characterType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _score.text = _healthScore.ToString();
	}

    public void Youtoober(bool type)
    {
        if(type == true)
        {
            _characterType = true;
        }
        else
        {
            _characterType = false;
        }
    }

    public void fruitScore(FruitScore score)
    {
        
        if(_characterType == true)
        {
            _sumNumber += ((float)score * 1.2f);
        }
        else
        {
            _sumNumber += (float)score;
        }
        _healthScore = (int)_sumNumber;
    }
}
