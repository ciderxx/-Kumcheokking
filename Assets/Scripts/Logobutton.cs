using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Logobutton : MonoBehaviour {

    public void OnclickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnclickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}