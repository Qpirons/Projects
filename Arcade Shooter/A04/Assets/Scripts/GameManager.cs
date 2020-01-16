using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject Gameover;
    public GameObject ScoreGameover;
    private bool isshowing = false;
    public static int Scorevalue = 0;
    public GameObject test;
    Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Scorevalue = 0;
        Score = GetComponent<Text>();
        Time.timeScale = 0;
        Gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Score != null && Time.timeScale != 0)
        {
            Score.text = "Score: " + Scorevalue;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            isshowing = !isshowing;
            menu.SetActive(isshowing);
            if(isshowing == true)
            {
                Time.timeScale = 0;
            }
            isshowing = !isshowing;
        }
        test = GameObject.Find("Ship");
        if (test == null)
        {
            Gameover.SetActive(true);
            ScoreGameover.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.R) && test == null)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
