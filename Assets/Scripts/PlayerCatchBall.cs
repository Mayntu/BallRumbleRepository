using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCatchBall : NetworkBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform handsPosition;
    public bool isCatched = false;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    private void Update()
    {
        if(!isLocalPlayer) return;
        if(isCatched)
        {
            ball.transform.position = handsPosition.position;
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (!isServer)
            return;
        
        NetworkIdentity networkIdentity = collider.GetComponent<NetworkIdentity>();
        if(networkIdentity != null && collider.CompareTag("Ball"))
        {
            isCatched = true;
            ball.transform.position = handsPosition.position;
            ball.GetComponent<PlayerThrowBall>().AssignPlayer(gameObject);
        }
    }
    private void OnTriggerExit(Collider collider)
    {

        NetworkIdentity networkIdentity = collider.GetComponent<NetworkIdentity>();
        if(networkIdentity != null && collider.CompareTag("Ball"))
        {
            isCatched = false;
            ball.GetComponent<PlayerThrowBall>().AssignPlayer(null);
        }
    }

}
