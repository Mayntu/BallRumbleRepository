using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class RedBotMovement : NetworkBehaviour
{

    [SerializeField] private GameObject ball;

    private NavMeshAgent AI_Agent;


    public bool isBot = true;

    private Animator animator;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerCatchBall>().IsCatched)
        {
            isBot = false;
        }

        if (isBot)
        {
            if(ball.GetComponent<PlayerThrowBall>().Player != null)
            {
                if (ball.GetComponent<PlayerThrowBall>().Player.tag == "RedPlayer")
                {
                    AI_Agent.SetDestination(ball.transform.position);
                    animator.SetFloat("speed", 0.4f);
                }
                else if (ball.GetComponent<PlayerThrowBall>().Player.tag == "BluePlayer")
                {
                    AI_Agent.SetDestination(ball.transform.position);
                    animator.SetFloat("speed", 0.4f);
                }
            }
            else
            {
                AI_Agent.SetDestination(ball.transform.position);
                animator.SetFloat("speed", 0.4f);
            }
            GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<RedBotMovement>().enabled = false; 
        }
    }
}
