using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnRedPlayer : NetworkBehaviour
{
    public GameObject redPlayerPrefab;
    void Start()
    {
        if(isServer)
        {
            CmdSpawnRedPlayer();
        }
    }

    [Command]
    private void CmdSpawnRedPlayer()
    {
        GameObject redPlayer = Instantiate(redPlayerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(redPlayer);
    }
}
