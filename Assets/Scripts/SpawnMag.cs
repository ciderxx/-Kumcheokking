using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMag : MonoBehaviour {

    private float _createTime = 0.7f; // 열매 스폰 딜레이

    public Transform[] _points; //자식들을 넣는 변수

    public GameObject _GibonImage; //프리펩을 넣을 변수 (기본열매)
    public GameObject _KumImage; //프리펩을 넣을 변수 (쿰척열매)
    public GameObject _MaImage; //프리펩을 넣을 변수 (마싯열매)
    public GameObject _GumImage; //프리펩을 넣을 변수 (금금열매)
    public GameObject _GorImage; //프리펩을 넣을 변수 (꼬르열매)
    public GameObject _AkImage; //프리펩을 넣을 변수 (어크열매)

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

                if (ranDom >= 1 && ranDom <= 68)
                { 
                    Instantiate(_GibonImage, _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 68 && ranDom <= 80)
                {
                    Instantiate(_GumImage, _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 80 && ranDom <= 85)
                {
                    Instantiate(_MaImage, _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 85 && ranDom <= 90)
                {
                    Instantiate(_KumImage, _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 90 && ranDom <= 95)
                {
                    Instantiate(_AkImage, _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 95 && ranDom <= 100)
                {
                    Instantiate(_GorImage, _points[idO].position, _points[idO].rotation);
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
