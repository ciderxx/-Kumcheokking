using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMag : MonoBehaviour {

    private float _createTime = 0.7f; // 열매 스폰 주기

    public Transform[] _points; //자식들을 넣는 변수
    public GameObject _GibonImage; //프리펩을 넣을 변수 (기본열매)
    public GameObject _KumImage; //프리펩을 넣을 변수 (쿰척열매)

    public int maxFruit = 55; //열매오브젝트가 있을수있는 제한
    public bool _isDownFruit = false; //음 게임실행변수

    void Awake()
    {
        
    }

    IEnumerator CreateFruit() //코루틴 메소드
    {
        while(!_isDownFruit)//true일때까지 실행함
        {
            int fruitCount = (int)GameObject.FindGameObjectsWithTag("Point").Length; //Point태그를 가진 각 게임오브젝트들을 갯수를 센뒤에 int형을 변환한뒤 넣는다.

            if(fruitCount < maxFruit){ //조건식은 약10 < 55이다
                yield return new WaitForSeconds(_createTime); //수치만큼 딜레이를 준다.

                int index = Random.Range(1, _points.Length); //인덱스 변수안에 랜덤수를 넣는다.

                Instantiate(_GibonImage, _points[index].position, _points[index].rotation); //Instantiate는 오브젝트를 생성하는 메소드이므로 랜덤한 위치에서 기본열매를 생성한다.
                //Instantiate(_KumImage, _points[index-1].position, _points[index].rotation);
            }
            else
            {
                yield return null; //코루틴안에 일이 끝났다면 코루틴을 끝을낸다
            }
        }
    }

    // Use this for initialization
    void Start () {
        _points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>(); //SpawnPoint가 가지고 있는 자식들의 트랜스폼을 넣는다

        if (_points.Length > 0) //배열의 저장된 갯수를 모두 검사한다.
        {
            StartCoroutine(CreateFruit());//코루틴을 실행한다 (코루틴은 스크립트내에서 다른 공간을 만들고 그 공간에서 지랄하는것을 말한다.)
        }
	}

	// Update is called once per frame
	void Update () {
	}
}
