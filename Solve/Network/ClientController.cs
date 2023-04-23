using System.Collections.Generic;
using UnityEngine;
// Dont forget to add at Packages/manifest.json
// at "dependencies" section
// High Level Multiplayer System "com.unity.multiplayer-hlapi": "1.1.1",
// It adds NetworkServer, NetworkMessage and NetworkBase
namespace Solve
{
  namespace Network
  {
    using Debug;
    public class ClientController : MonoBehaviour
    {
      private static ClientController _instance;
      private static List<ServerConnection> connections = new List<ServerConnection>();
      public void Awake()
      {
        _instance = this;
      }
      public static void SendToServer(string ip, int port, short messageId, byte[] message)
      {
        DebugController.Log(typeof(ClientController), "Creating a new server connection");
        GameObject connection = new GameObject("Connection");
        connection.transform.SetParent(_instance.transform);
        ServerConnection serverConnection = connection.AddComponent<ServerConnection>();
        serverConnection.Send(ip, port, messageId, message);
        connections.Add(serverConnection);
      }
      public void OnDestroy ()
      {
        foreach (ServerConnection connection in connections)
        {
          if (connection != null)
            connection.Disconnect();
        }
      }
    }
  }
}
