using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Touch : MonoBehaviour {

    private Player _playerScript;

    private Vector2 _point;

    void Start()
    {
        _playerScript = FindObjectOfType<Player>();
    }

    private void Update()
    {
#if UNITY_ANDROID
        TouchPoint();
#endif
    }

    public void TouchPoint()
    {
#if UNITY_ANDROID
        Vector2 TouchPoint = Input.GetTouch(0).position;
        
        _point = Camera.main.ScreenToViewportPoint(TouchPoint);

        if(Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            if (_point.x < 0.5f)
            {
                _playerScript.type = 1;
            }
            if (_point.x > 0.5f)
            {
                _playerScript.type = -1;
            }
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _playerScript.type = 0;
        }
#endif
    }
}
