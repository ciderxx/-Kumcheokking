using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMag : MonoBehaviour {

    private float _createTime = 0.7f; // 열매 스폰 딜레이

    private Transform[] _points; //자식들을 넣는 변수

    [Header("Image")]

    public GameObject[] _fImages;

    [Header("A")]

    public int _maxFruit = 55; //열매오브젝트가 있을수있는 제한
    public bool _isDownFruit = false; //음 게임실행변수

    private int _fruitIngame;

    void Awake()
    {
        
    }

    IEnumerator CreateFruit()
    {
        while(!_isDownFruit)
        {
            if(_fruitIngame < _maxFruit){
                int ranDom = Random.Range(1, 100);

                yield return new WaitForSeconds(_createTime);

                int idO = Random.Range(1, _points.Length);

                if (ranDom >= 1 && ranDom <= 68) // 기본
                { 
                    Instantiate(_fImages[0], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 68 && ranDom <= 80) // 금금
                {
                    Instantiate(_fImages[1], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 80 && ranDom <= 85) // 마싯
                {
                    Instantiate(_fImages[2], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 85 && ranDom <= 90) // 쿰척
                {
                    Instantiate(_fImages[3], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 90 && ranDom <= 95) // 꼬르
                {
                    Instantiate(_fImages[4], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 95 && ranDom <= 100) // 어크
                {
                    Instantiate(_fImages[5], _points[idO].position, _points[idO].rotation);
                }
            }
            else
            {
                yield break; //코루틴안에 일이 끝났다면 코루틴을 끝을낸다
            }
        }
    }

    // Use this for initialization
    void Start () {
        _points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>(); 

        _fruitIngame = (int)GameObject.FindGameObjectsWithTag("Point").Length;

        if (_points.Length > 0) 
        {
            StartCoroutine(CreateFruit());
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
