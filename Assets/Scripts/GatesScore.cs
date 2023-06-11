using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesScore : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("BlueGatesTrigger"))
		{
			player.GetComponent<PlayerMovement>().RedScore += 2;
		}
		else if(other.CompareTag("RedGatesTrigger"))
		{
			player.GetComponent<PlayerMovement>().BlueScore += 2;
		}
	}
}
