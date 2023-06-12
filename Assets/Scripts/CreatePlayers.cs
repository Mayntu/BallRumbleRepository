using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{

    public NetworkManager networkManager;
    public GameObject red;
    public bool isRed = false;
    private bool canSpawn = true; 

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("SpawnRedPlayer"))
        {
            int boolValue = PlayerPrefs.GetInt("SpawnRedPlayer");
            isRed = boolValue == 1 ? true : false;
            Debug.Log("sadsad");
        }

        if (isRed == true && canSpawn == false)
        {
            Debug.Log("daniil pipiska");
            networkManager.playerPrefab = red;
            networkManager.StartClient();
            canSpawn = false;
        }
    }
}
