using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static int score = 0;

    public Text scoreText;

    private void Start()
    {
        SetScoreText();
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(score);
        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
