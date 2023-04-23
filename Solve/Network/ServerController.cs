using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
// Dont forget to add at Packages/manifest.json
// at "dependencies" section
// High Level Multiplayer System "com.unity.multiplayer-hlapi": "1.1.1",
// It adds NetworkServer, NetworkMessage and NetworkBase
namespace Solve
{
  namespace Network
  {
    using Debug;
    [System.Obsolete]
    public class ServerController : MonoBehaviour
    {
      public UnityEvent<byte[]> onReceive;
      private static ServerController _instance;
      public void Awake()
      { _instance = this; }
      public static void StartServer(short messageId, int port)
      {
        NetworkServer.Listen(port);
        NetworkServer.RegisterHandler(messageId, _instance.OnReceiveObject);
        DebugController.Log(typeof(ServerController), "Server started at port " + port);
      }
      public void OnReceiveObject(NetworkMessage networkMessage)
      {
        DebugController.Log(typeof(ServerController), "Message received");  
        Message message = networkMessage.ReadMessage<Message>();
        onReceive?.Invoke(message.bytes);
        networkMessage.conn.Disconnect();
      }
    }
  }
}
