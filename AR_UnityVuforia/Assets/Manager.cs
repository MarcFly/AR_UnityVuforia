using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public bool playing;
    public float timer;
    public float timer_2;
    public int points;
    public GameObject[] Fruits = new GameObject[9];
    public int current_good_fruit;

    public Button StartB;
    public Button HowToB;
    public GameObject UICanvas;

	// Use this for initialization
	void Start () {
        playing = false;
        timer = 0;
        timer_2 = 0;
        points = 0;
        current_good_fruit = 10;

        StartB = GameObject.FindGameObjectWithTag("StartB").GetComponent<Button>();
        StartB.onClick.AddListener(StartPlay);

        UICanvas = GameObject.FindGameObjectWithTag("Respawn");
    }
	
	// Update is called once per frame
	void Update () {
        if (playing)
        {
            timer += Time.deltaTime;
            timer_2 += Time.deltaTime;

            if(timer_2 > 5000)
            {
                current_good_fruit = Random.Range(0, 8);
            }
        }

        if(timer > 60000)
        {
            playing = false;
            timer = 0;
            timer_2 = 0;
            UICanvas.SetActive(true);
        }

	}
    
    public void StartPlay()
    {
        playing = true;
        timer = 0;
        timer_2 = 0;
        points = 0;
        current_good_fruit = Random.Range(0, 8);
        UICanvas.SetActive(false);
    }
}
