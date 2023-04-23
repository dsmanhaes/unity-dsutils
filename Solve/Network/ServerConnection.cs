using System.Collections;
using UnityEngine;
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
    public class ServerConnection : MonoBehaviour
    {
      private NetworkClient _client;
      private short _messageId;
      private byte[] _message;
      private NetworkMessage _networkMessage;
      public void Send(string ip, int port, short messageId, byte[] message)
      {
        _messageId = messageId;
        _message = message;
        _client = new NetworkClient();
        _client.Connect(ip, port);
        _client.RegisterHandler(MsgType.Connect, OnConnect);
      }
      private void OnConnect(NetworkMessage networkMessage)
      {
        DebugController.Log(typeof(ServerConnection), "Connected to server at: "
          + _client.serverIp + _client.serverPort);
        Message message = new Message(_message);
        _client.Send(_messageId, message);
        _networkMessage = networkMessage;
        StartCoroutine(Disconnect());
      }
      public IEnumerator Disconnect()
      {
        yield return new WaitForSeconds(2.5f);
        DebugController.Log(typeof(ServerConnection), "Disconnecting message: " + _messageId);
        _networkMessage.conn.Disconnect();
      }
    }
  }
}
