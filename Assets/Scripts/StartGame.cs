using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : NetworkBehaviour
{
    public GameObject bluePlayerPrefab;
    public GameObject spawnRedPlayer;

    public NetworkManager networkManager;

    public void ConnectAsBluePlayer()
    {
        networkManager.playerPrefab = bluePlayerPrefab;
        networkManager.StartClient();
        Debug.Log("1");
    }

    // public void ConnectAsRedPlayer()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    //     SceneManager.LoadScene("SampleScene1");
    //     Debug.Log("1");
    // }

    // private void OnDestroy()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     if (scene.name == "SampleScene1")
    //     {
    //         NetworkServer.Listen(7777); // Указываем порт, который будет прослушивать сервер
    //         Debug.Log("2"); 
    //         CmdSpawnRedPlayer();
    //     }
    // }

    // [Command]
    // private void CmdSpawnRedPlayer()
    // {
    //     GameObject redPlayer = Instantiate(redPlayerPrefab, Vector3.zero, Quaternion.identity);
    //     NetworkServer.Spawn(redPlayer);
    // }
    public void ConnectAsRedPlayer()
    {
        spawnRedPlayer.SetActive(true);
    }
}
