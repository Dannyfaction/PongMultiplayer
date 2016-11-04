using UnityEngine;
using System.Collections;

public class GoalCollision : MonoBehaviour {

    public delegate void GoalEvent(int player);
    public static event GoalEvent OnGoalEvent;

    //The name of the tag on the Goal
    private string leftGoalTag = "Left";

    void OnTriggerEnter2D(Collider2D col)
    {
        //If there is a collision, check which goal the ball has collided with
        if (transform.tag == leftGoalTag)
        {
            //Event for the ScoreManager
            OnGoalEvent(2);

            //Remove the Ball once there has been scored
            GameObject.Destroy(col.gameObject);
        }else
        {
            //Event for the ScoreManager
            OnGoalEvent(1);

            //Remove the Ball once there has been scored
            GameObject.Destroy(col.gameObject);
        }
    }
}