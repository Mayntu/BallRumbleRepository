// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Mirror;

// public class PlayerCollision : NetworkBehaviour
// {
//     public float recoveryTime = 2f;

//     private bool isDown = false;

//     private void OnCollisionEnter(Collision collision)
//     {
//         if (!isDown && collision.gameObject.CompareTag("Player"))
//         {
//             isDown = true;

//             // Блокировка движения игроков
//             RpcDisableMovement();

//             Invoke("EnableMovement", recoveryTime);
//         }
//     }

//     [ClientRpc]
//     private void RpcDisableMovement()
//     {
//         if (isLocalPlayer)
//         {
//             // Блокировка движения локального игрока
//             GetComponent<PlayerMovement>().enabled = false;
//         }
//     }

//     private void EnableMovement()
//     {
//         if (isLocalPlayer)
//         {
//             // Включение движения локального игрока
//             GetComponent<PlayerMovement>().enabled = true;
//         }
//         isDown = false;
//     }
// }
