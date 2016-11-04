using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BallSpawner : NetworkBehaviour {

    //The name of the prefab in the resources list
    private string ballString = "Ball";

	void Start () {
        Playermovement.OnClientsConnectEvent += CmdSpawnBall;
	}

    //Spawn the ball on the Server
    [Command]
    public void CmdSpawnBall()
    {
        // Create the ball from the ball prefab
        var ball = (GameObject)Instantiate(Resources.Load(ballString), new Vector2(0, 0), Quaternion.identity);

        // Spawn the ball on the Server and on the client
        NetworkServer.Spawn(ball);
    }
}
