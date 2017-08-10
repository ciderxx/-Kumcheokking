using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Hunger _hungerScript;
    public Score _scoreScript;

    public float _moveSpeed = 5f;

    public float _stopPointR = 3.125f;
    public float _stopPointL = -3.125f;

    public GameObject leftPoint = null;

    void Move()
    {
        Vector3 scale = transform.localScale;

        bool direction = true;

        float moveDis = _moveSpeed * Time.deltaTime; //이동을 하게 하는 속력같은것
        Vector2 move = new Vector2(moveDis, 0); // 벡터2의 좌표값에 내가 가고싶은 값을 넣어줌

        //캐릭터 뒤집기
        if (Input.GetAxisRaw("Horizontal") < 0) // 왼쪽을 눌렀는가
        {
            direction = true;
        }
        if (Input.GetAxisRaw("Horizontal") > 0) //오른쪽을 눌렀는가
        {
            direction = false;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            return;
        }
        if (direction == false) // 왼쪽으로 가는도중 오른쪽으로 갈려한다면
        {
            scale.x = -1;
            transform.localScale = scale;
        }
        if (direction == true) // 오른쪽으로 가는도중 왼쪽으로 갈려한다면
        {
            scale.x = 1;
            transform.localScale = scale;
        }

        if(scale.x == 1) //멀쩡할때
        {
            if (Input.GetAxisRaw("Horizontal") < 0 && leftPoint.transform.position.x > _stopPointL) // 왼쪽을 눌렀는가
            {
                transform.position -= (Vector3)move; // 위 조건식이 맞다면 왼쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
            else
            {
                return;
            }
        }
        if(scale.x == -1) // 뒤집혔을때
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && leftPoint.transform.position.x < _stopPointR) //오른쪽을 눌렀는가
            {
                transform.position += (Vector3)move; // 위 조건식이 맞다면 오른쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public void OnTriggerEnter2D(Collider2D fruit)
    {
        if(fruit.transform.tag == "gibon")
        {
            _hungerScript.HpUp(Hunger.FruitType.gibon);
            _scoreScript.fruitScore(Score.FruitScore.gibon);
        }
        if (fruit.transform.tag == "gumgum")
        {
            _hungerScript.HpUp(Hunger.FruitType.gumgum);
            _scoreScript.fruitScore(Score.FruitScore.gumgum);
        }
        if (fruit.transform.tag == "ggoRrrrrr")
        {
            _hungerScript.HpUp(Hunger.FruitType.ggoRrrrrr);
            _scoreScript.fruitScore(Score.FruitScore.ggoRrrrrr);
        }
        if (fruit.transform.tag == "aku")
        {
            _hungerScript.HpUp(Hunger.FruitType.aku);
            _scoreScript.fruitScore(Score.FruitScore.aku);
        }
        if (fruit.transform.tag == "masit")
        {
            _hungerScript.HpUp(Hunger.FruitType.masit);
            _scoreScript.fruitScore(Score.FruitScore.masit);
        }
        if (fruit.transform.tag == "kumchuk")
        {
            _hungerScript.HpUp(Hunger.FruitType.kumchuk);
            _scoreScript.fruitScore(Score.FruitScore.kumchuk);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
}
