using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public bool playing;
    public float timer;
    public float timer_2;
    public int points;
    public GameObject UICanvas;
    public GameObject[] Fruits = new GameObject[9];
    public int current_good_fruit;
    public int past_score;
    public Button StartB;

    public Text score;
    public Text bonusFruit;
    public Text TimeText;

    // Use this for initialization
    void Start () {
        playing = false;
        timer = 0;
        timer_2 = 0;
        points = 0;
        past_score = points;
        current_good_fruit = 10;
        StartB = GameObject.FindGameObjectWithTag("StartB").GetComponent<Button>();
        StartB.onClick.AddListener(StartPlay);
        UICanvas = GameObject.FindGameObjectWithTag("Respawn");

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        TimeText = GameObject.FindGameObjectWithTag("HowB").GetComponent<Text>();
        bonusFruit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playing)
        {
            timer += Time.deltaTime;
            timer_2 += Time.deltaTime;

            if(timer_2 > 5)
            {
                current_good_fruit = Random.Range(0, 8);
                timer_2 = 0;
            }

            if(points != past_score)
            {
                score.text = "Score: " + points.ToString();
                past_score = points;
            }
        }

        if(timer > 30)
        {
            playing = false;
            timer = 0;
            timer_2 = 0;
            UICanvas.SetActive(true);
            current_good_fruit = 10;
        }

        score.text = points.ToString();
        TimeText.text = timer.ToString();
        if(current_good_fruit < 10)
            bonusFruit.text = Fruits[current_good_fruit].name;
        else
            bonusFruit.text = "Bonus Fruit";
    }
    
    public void StartPlay()
    {
        playing = true;
        timer = 0;
        timer_2 = 0;
        points = 0;
        past_score = points;
        current_good_fruit = Random.Range(0, 8);
        UICanvas.SetActive(false);
    }
}
