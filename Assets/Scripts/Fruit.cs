using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public float _downSpeed = 5f;
    private float _stopPointB = -4.6f;

    GameObject _bottomPoint = null;

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
            //Instantiate();
            Destroy(gameObject, 0.12f);
            return;
        }
    }


 

    // Use this for initialization
    void Start () {
      _bottomPoint = transform.FindChild("bottomPoint").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Down();
	}
}
