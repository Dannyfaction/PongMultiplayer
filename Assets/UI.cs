using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private string scoreTransformName = "Score";

    private Text scoreText;

	void Start () {
        //Find the 'Score' transform under the UI and grab the Text Component
        scoreText = transform.Find(scoreTransformName).GetComponent<Text>();

        ScoreManager.OnScoreChangeEvent += UpdateScore;
	}

    //Update the score once a goal has been made
    void UpdateScore(float leftScore, float rightScore)
    {
        scoreText.text = leftScore + " - " + rightScore;
    }
}