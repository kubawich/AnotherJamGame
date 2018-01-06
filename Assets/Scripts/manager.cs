using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

    public static manager @object;
    public Canvas InGameUI, MenuUI, HUDUI;
    public Text FPS, Debug;
    public GameObject player,VCam;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        @object = this;
        Time.timeScale = 1;
    }

    public void Update()
    {
        float t = 1f / Time.deltaTime;
        FPS.text = t.ToString(); 
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);      
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        PlayerDiedUIOn();
    }

    private void PlayerDiedUIOn()
    {
        InGameUI.gameObject.SetActive(true);
        HUDUI.gameObject.SetActive(false);
        InGameUI.transform.GetChild(0).GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "10 points";
    }

    private void PlayerDiedUIOff()
    {
        InGameUI.gameObject.SetActive(false);
        HUDUI.gameObject.SetActive(true);
    }
}
