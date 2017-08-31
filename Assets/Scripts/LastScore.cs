using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LastScore : MonoBehaviour {

    public Text _lastScore;

    private int _allScore;
    private int _firstScore = 0;
    private int _stepScore = 0;

    // Use this for initialization
    void Start () {
        AllScore();
    }

    void Update()
    {
        StartCoroutine(StepScore());
    }

    void AllScore()
    {
        _allScore = PlayerPrefs.GetInt("LastScore");
        PlayerPrefs.Save();
    }

    IEnumerator StepScore()
    {
        if(_firstScore <= _allScore)
        {
            _firstScore = _firstScore + (5 + _stepScore);
            _stepScore += 17;
            if(_firstScore > _allScore)
            {
                _firstScore = _allScore;
            }
            _lastScore.text = _firstScore.ToString();
        }
        else
        {
            yield break;
        }
    }
}
