using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //public GameObject menu;
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
        Gameover.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score != null && Time.timeScale != 0)
        {
            Score.text = "Score: " + Scorevalue;
        }
        test = GameObject.Find("Player");
        if (test == null)
        {
            Gameover.SetActive(true);
            ScoreGameover.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.R) && test == null)
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
