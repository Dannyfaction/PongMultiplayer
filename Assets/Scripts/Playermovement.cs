using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Playermovement : NetworkBehaviour {

    public delegate void ClientsConnectEvent();
    public static event ClientsConnectEvent OnClientsConnectEvent;

    private Vector2 mousePos;

    private NetworkIdentity nWIdentity;

	void Start () {
        nWIdentity = GetComponent<NetworkIdentity>();
        mousePos = new Vector2();

        //Spawn the ball when the 2nd client has connected
        if (!nWIdentity.isServer)
        {
            OnClientsConnectEvent();
        }
    }
	
	void Update () {
        //Only apply the Update function when this is the local player
        if (!isLocalPlayer)
        {
            return;
        }

        //Get Mouse Position on screen and change it to world position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Change the player's Y position to the mouse Y position (inside screen boundary)
        if (mousePos.y < 4 && mousePos.y > -4)
        {
            transform.position = new Vector2(transform.position.x, mousePos.y);
        }
    }

    //Set the current Player Color to Green to identify the player
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
