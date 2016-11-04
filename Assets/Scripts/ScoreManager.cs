using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class ScoreManager : NetworkBehaviour {

    //Event for the UI
    public delegate void ScoreChangeEvent(float leftScore, float rightScore);
    public static event ScoreChangeEvent OnScoreChangeEvent;

    //Sync the score between clients
    [SyncVar]
    private float leftScore;
    [SyncVar]
    private float rightScore;

    //Amount of score to add when a goal has been made
    private float scoreAmount = 1;

	void Start () {
        //When collision has been made, add score
        GoalCollision.OnGoalEvent += AddScore;
    }

    void AddScore(int player)
    {
        if (player == 1)
        {
            //Add score
            leftScore += scoreAmount;
        }else
        {
            //Add score
            rightScore += scoreAmount;
        }
        //Send the score to the UI script
        OnScoreChangeEvent(leftScore, rightScore);
    }
}
