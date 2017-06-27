using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    private float _topPoint = -3.0f;
    private float _botPoint = -3.5f;

    private Rigidbody2D _Fruit;
    private Collision2D _coll;

    public float _downSpeed = 5f;
    private float _stopPointB = -4.6f;

    public GameObject _bottomPoint;

    void Down()
    {
        float down = _downSpeed * Time.deltaTime;
        Vector3 fruitPo = new Vector3(0, down);

        if(_bottomPoint.transform.position.y > _stopPointB)
        {
            transform.position -= fruitPo;
        }
        else
        {
            Destroy(gameObject, 0.12f);
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            if (_bottomPoint.transform.position.y < _topPoint && _bottomPoint.transform.position.y > _botPoint)
            {
                Destroy(this.gameObject);
                Debug.Log("11");
            }
        }
        else
        {
            Debug.Log("22");
            return;
        }
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
        Down();
	}
}
