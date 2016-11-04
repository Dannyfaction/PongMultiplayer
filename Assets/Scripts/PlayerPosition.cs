using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPosition : MonoBehaviour {

    private Transform leftPlayerSpawnPositionTransform;
    private Transform rightPlayerSpawnPositionTransform;

    //The name of the Left/Right Player Spawn Position Transform
    private string leftPlayerSpawnPositionName = "LeftPlayerSpawnPosition";
    private string rightPlayerSpawnPositionName = "RightPlayerSpawnPosition";

    private NetworkIdentity nWIdentity;

	void Start () {
        //Find the left and right spawnpoint's transforms
        leftPlayerSpawnPositionTransform = GameObject.Find(leftPlayerSpawnPositionName).transform;
        rightPlayerSpawnPositionTransform = GameObject.Find(rightPlayerSpawnPositionName).transform;

        //For checking if the player is the first or second client connecting
        nWIdentity = GetComponent<NetworkIdentity>();

        //Spawn the first player left and the second player right
        if (!nWIdentity.isServer)
        {
            transform.position = rightPlayerSpawnPositionTransform.position;
        }else
        {
            transform.position = leftPlayerSpawnPositionTransform.position;
        }
    }
}