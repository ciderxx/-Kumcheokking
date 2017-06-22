using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour {

    private float _downSpeed = 3f;
    private float _stopPointB = -4.6f;

    GameObject _bottomPoint = null;

    void Down()
    {
        float down = _downSpeed * Time.deltaTime;
        Vector2 fruitPo = new Vector2(0, down);

        _bottomPoint = transform.FindChild("bottomPoint").gameObject;

        if(_bottomPoint.transform.position.y > _stopPointB)
        {
            transform.position -= (Vector3)fruitPo;
        }
        else
        {
            //Instantiate();
            Destroy(gameObject, 0.12f);
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
