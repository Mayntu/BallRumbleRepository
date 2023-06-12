// using UnityEngine;
// using UnityEngine.UI;
// using Mirror;

// public class NetworkCustom : NetworkManager
// {
//     public int chosenCharacter = 0;
//     public GameObject[] characters;
//     public Button btn1;
//     public Button btn2;

//     public override void OnServerAddPlayer(NetworkConnection conn, NetworkIdentity player)
//     {
//         GameObject newPlayer;
//         Transform startPos = GetStartPosition();

//         if (startPos != null)
//         {
//             newPlayer = Instantiate(characters[chosenCharacter], startPos.position, startPos.rotation);
//         }
//         else
//         {
//             newPlayer = Instantiate(characters[chosenCharacter], Vector3.zero, Quaternion.identity);
//         }

//         // Присоединяем NetworkIdentity к игроку
//         NetworkServer.AddPlayerForConnection(conn, newPlayer);

//         // Теперь можно выполнить дополнительные настройки или инициализацию для игрока
//     }

//     public override void OnClientConnect(NetworkConnection conn)
//     {
//         base.OnClientConnect(conn);

//         // Добавьте свою логику, выполняющуюся при подключении клиента к серверу
//     }

//     public void ChooseCharacter(int characterIndex)
//     {
//         chosenCharacter = characterIndex;
//     }

//     private void Start()
//     {
//         btn1.onClick.AddListener(() => ChooseCharacter(0));
//         btn2.onClick.AddListener(() => ChooseCharacter(1));
//     }
// }
