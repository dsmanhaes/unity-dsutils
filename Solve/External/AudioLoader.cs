namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      using System;
      using System.IO;
      using UnityEngine;
      using UnityEngine.Networking;
      using NAudio.Lame;
      using NAudio.Wave.WZT;
      using Debug;
      public static class AudioLoader
      {
        public const int HEADER_SIZE = 44;
        public static AudioClip LoadAudio(string filePath, string placeholderPath)
        {
          AudioClip clip;
          if (!File.Exists(filePath))
          {
            clip = Resources.Load<AudioClip>(placeholderPath);
            Save(clip, filePath, 320);
            DebugController.Log(typeof(AudioLoader), "Created placeholder at: " + filePath);
          }
          DebugController.Log(typeof(AudioLoader), "Loading file at: " + filePath);
          using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.UNKNOWN))
          {
            webRequest.SendWebRequest();
            while (!webRequest.isDone) { }
            clip = DownloadHandlerAudioClip.GetContent(webRequest);
          }
          DebugController.Log(typeof(AudioLoader), "Loaded file at: " + filePath);
          return clip;
        }
        private static void Save(AudioClip clip, string filePath, int bitRate)
        {
          byte[] wavFile = GetWav(clip);
          var retMs = new MemoryStream();
          var ms = new MemoryStream(wavFile);
          var rdr = new WaveFileReader(ms);
          var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, bitRate);
          rdr.CopyTo(wtr);
          byte[] mp3File = retMs.ToArray();
          File.WriteAllBytes(filePath, mp3File);
        }
        private static byte[] GetWav(AudioClip clip)
        {
          byte[] bytes = new byte[HEADER_SIZE + clip.samples * clip.channels * 2];
          // Creating Header
          int hz = clip.frequency;
          int channels = clip.channels;
          UInt16 bps = 16;
          UInt16 one = 1;
          byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
          riff.CopyTo(bytes, 0);
          byte[] chunkSize = BitConverter.GetBytes(bytes.Length - 8);
          chunkSize.CopyTo(bytes, 4);
          byte[] wave = System.Text.Encoding.ASCII.GetBytes("WAVE");
          wave.CopyTo(bytes, 8);
          byte[] fmt = System.Text.Encoding.ASCII.GetBytes("fmt ");
          fmt.CopyTo(bytes, 12);
          byte[] subChunk1 = BitConverter.GetBytes(16);
          subChunk1.CopyTo(bytes, 16);
          byte[] audioFormat = BitConverter.GetBytes(one);
          audioFormat.CopyTo(bytes, 20);
          byte[] numChannels = BitConverter.GetBytes((ushort)channels);
          numChannels.CopyTo(bytes, 22);
          byte[] sampleRate = BitConverter.GetBytes(hz);
          sampleRate.CopyTo(bytes, 24);
          byte[] byteRate = BitConverter.GetBytes(hz * channels * 2);
          byteRate.CopyTo(bytes, 28);
          byte[] blockAlign = BitConverter.GetBytes((ushort)(channels * 2));
          blockAlign.CopyTo(bytes, 32);
          byte[] bitsPerSample = BitConverter.GetBytes(bps);
          bitsPerSample.CopyTo(bytes, 34);
          byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
          datastring.CopyTo(bytes, 36);
          byte[] subChunk2 = BitConverter.GetBytes(clip.samples * channels * 2);
          subChunk2.CopyTo(bytes, 40);
          // Filling with the audio
          float[] samples = new float[clip.samples * clip.channels];
          clip.GetData(samples, 0);
          Int16[] intData = new Int16[samples.Length];
          byte[] bytesData = new byte[samples.Length * 2];
          float rescaleFactor = 32767;
          for (int i = 0; i < samples.Length; i++)
          {
            intData[i] = (short)(samples[i] * rescaleFactor);
            byte[] byteArr = new byte[2];
            byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
          }
          // Mounting the result
          bytesData.CopyTo(bytes, HEADER_SIZE);
          return bytes;
        }
      }
    }
  }
}
