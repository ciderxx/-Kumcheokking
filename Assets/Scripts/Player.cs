using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Hunger _hungerScript;
    private Score _scoreScript;

    private float _moveStop = 0f;
    private float _moveHurry = 10f;

    private float _moveSpeed = 3.3f;
    private float _stopTime = 0.8f;

    public float _stopPointR;
    public float _stopPointL;

    public GameObject leftPoint = null;

    private bool _direction;
    private int _type;

    // Use this for initialization
    void Start()
    {
        _hungerScript = GameObject.FindObjectOfType<Hunger>();
        _scoreScript = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Nuteom(bool If)
    {
        if (If == true)
        {
            _moveSpeed = 4.0f;
        }
        else
        {
            _moveSpeed = 3.3f;
        }
    }

    public int type
    {
        set
        {
            _type = value;
        }
    }

    void Move()
    {
        Vector3 scale = transform.localScale;

        float horizonPoint = Input.GetAxisRaw("Horizontal");
        float leftPoinrX = leftPoint.transform.position.x;

        float moveDis = _moveSpeed * Time.deltaTime; //이동을 하게 하는 속력같은것
        Vector2 move = new Vector2(moveDis, 0); // 벡터2의 좌표값에 내가 가고싶은 값을 넣어줌

#if UNITY_EDITOR
        //캐릭터 뒤집기
        _direction = (horizonPoint < 0);
        if (horizonPoint == 0)
        {
            return;
        }

        if(_direction) //멀쩡할때
        {
            scale.x = 1;
            transform.localScale = scale;
            if (horizonPoint < 0 && leftPoinrX > _stopPointL) // 왼쪽을 눌렀는가
            {
                transform.position -= (Vector3)move; // 위 조건식이 맞다면 왼쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
        }
        if(!_direction) // 뒤집혔을때
        {
            scale.x = -1;
            transform.localScale = scale;
            if (horizonPoint > 0 && leftPoinrX < _stopPointR) //오른쪽을 눌렀는가
            {
                transform.position += (Vector3)move; // 위 조건식이 맞다면 오른쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
        }
#elif UNITY_ANDROID
        if (_type == 1) //멀쩡할때
        {
            scale.x = 1;
            transform.localScale = scale;
            if (_type == 1 && leftPoinrX > _stopPointL) // 왼쪽을 눌렀는가
            {
                transform.position -= (Vector3)move; 
            }
        }
        if (_type == -1) // 뒤집혔을때
        {
            scale.x = -1;
            transform.localScale = scale;
            if (_type == -1 && leftPoinrX < _stopPointR) //오른쪽을 눌렀는가
            {
                transform.position += (Vector3)move;
            }
        }
        if(_type == 0)
        {
            transform.position = this.transform.position;
        }
#endif
    }

    public void OnTriggerEnter2D(Collider2D fruit)
    {
        if (fruit.transform.CompareTag("gibon"))
        {
            _hungerScript.HpUp(Hunger.FruitType.gibon);
            _scoreScript.fruitScore(Score.FruitScore.gibon);
        }
        if (fruit.transform.CompareTag("gumgum"))
        {
            _hungerScript.HpUp(Hunger.FruitType.gumgum);
            _scoreScript.fruitScore(Score.FruitScore.gumgum);
        }
        if (fruit.transform.CompareTag("ggoRrrrrr"))
        {
            _hungerScript.HpUp(Hunger.FruitType.ggoRrrrrr);
            _scoreScript.fruitScore(Score.FruitScore.ggoRrrrrr);
        }
        if (fruit.transform.CompareTag("aku"))
        {
            _hungerScript.HpUp(Hunger.FruitType.aku);
            _scoreScript.fruitScore(Score.FruitScore.aku);
            StartCoroutine(AkuFruitTimer());
        }
        if (fruit.transform.CompareTag("masit"))
        {
            _hungerScript.HpUp(Hunger.FruitType.masit);
            _scoreScript.fruitScore(Score.FruitScore.masit);
        }
        if (fruit.transform.CompareTag("kumchuk"))
        {
            _hungerScript.HpUp(Hunger.FruitType.kumchuk);
            _scoreScript.fruitScore(Score.FruitScore.kumchuk);
            StartCoroutine(KumchukFruitTimer());
        }
    }

    IEnumerator AkuFruitTimer()
    {
        _moveSpeed = _moveStop;
        yield return new WaitForSeconds(_stopTime);

        if(_moveSpeed == _moveStop)
        {
            _moveSpeed = 3.3f;
            yield break;
        }
    }

    IEnumerator KumchukFruitTimer()
    {
        _moveSpeed = _moveHurry;
        yield return new WaitForSeconds(_stopTime);

        if(_moveSpeed == _moveHurry)
        {
            _moveSpeed = 3.3f;
            yield break;
        }
    }
	
}
