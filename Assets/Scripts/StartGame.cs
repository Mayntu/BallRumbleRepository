using UnityEngine;
using Mirror;

public class StartGame : MonoBehaviour
{
    public NetworkManager networkManager;
    public string serverAddress = "localhost";
    public GameObject bluePlayerPrefab;
    public GameObject redPlayerPrefab;

    public void ConnectAndCreateBluePlayer()
    {
        networkManager.networkAddress = serverAddress;
        networkManager.playerPrefab = bluePlayerPrefab;
        networkManager.StartClient();
    }

    public void ConnectAndCreateRedPlayer()
    {
        networkManager.networkAddress = serverAddress;
        networkManager.playerPrefab = redPlayerPrefab;
        networkManager.StartClient();
    }
}