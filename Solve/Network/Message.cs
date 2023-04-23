using UnityEngine.Networking;
namespace Solve
{
  namespace Network
  {
    [System.Obsolete]
    public class Message : MessageBase
    {
      public byte[] bytes;
      public Message() { }
      public Message(byte[] bytes)
      {
        this.bytes = bytes;
      }
    }
  }
}
