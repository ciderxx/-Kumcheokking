using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    private float _topPoint = -2.7f;
    private float _botPoint = -3.6f;

    public float _downSpeed = 5f;

    public int _sumNumber = 0;
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

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.transform.tag == "Player")
        {
            if (_bottomPoint.transform.position.y < _botPoint)
            {
                //Debug.Log("못먹음");
            }
            else if (_bottomPoint.transform.position.y < _topPoint && _bottomPoint.transform.position.y > _botPoint)
            {
                Destroy(this.gameObject);
                //Debug.Log("먹음");
            }
            else
            {
                //Debug.Log("떨어짐");
                return;
            }
        }
        else
        {
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
