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
        networkManager.StartClient();

        // Создаем и спауним синего игрока
        GameObject bluePlayer = Instantiate(bluePlayerPrefab);
        NetworkServer.Spawn(bluePlayer);
    }

    public void ConnectAndCreateRedPlayer()
    {
        networkManager.networkAddress = serverAddress;
        networkManager.StartClient();

        // Создаем и спауним красного игрока
        GameObject redPlayer = Instantiate(redPlayerPrefab);
        NetworkServer.Spawn(redPlayer);
    }
}
