using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Ballmovement : MonoBehaviour {

    private Rigidbody2D rigidBody;

    //Amount of force at which the ball get sends off at start
    private float forceAmount = 250;

	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        
        //Sends the ball either to the left/up or to the right/up, chosen at random
        int randomNum = Random.Range(0, 2);
        switch (randomNum)
        {
            case 0:
                rigidBody.AddForce(-transform.right * forceAmount);
                rigidBody.AddForce(transform.up * forceAmount);
                break;
            case 1:
                rigidBody.AddForce(transform.right * forceAmount);
                rigidBody.AddForce(transform.up * forceAmount);
                break;
        }
	}
}