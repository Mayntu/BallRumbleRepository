using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartServer : MonoBehaviour
{
    private NetworkManager networkManager;

    private void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
        networkManager.StartServer();
    }
}
