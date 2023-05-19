namespace Solve
{
  namespace ExternalResources
  {
    using System;
    using System.IO;
    using UnityEngine;
    using UnityEngine.Networking;
    using Debug;

    public static class AudioLoader
    {
      public static AudioClip LoadAudio(string filePath, string placeholderPath)
      {
        AudioClip clip;
        if (File.Exists(filePath))
        {
          DebugController.Log(typeof(AudioLoader), "Loading file at: " + filePath);
          using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.MPEG))
          {
            webRequest.SendWebRequest();
            while (!webRequest.isDone) { }
            clip = DownloadHandlerAudioClip.GetContent(webRequest);
          }
          DebugController.Log(typeof(AudioLoader), "Loaded file at: " + filePath);
        }
        else
        {
          clip = Resources.Load<AudioClip>(placeholderPath);
          Save(filePath, clip);
          DebugController.Log(typeof(AudioLoader), "Created placeholder at: " + filePath);
        }
        return clip;
      }
      public static void Save(string filepath, AudioClip clip)
      {
        // Create a new WAV file
        FileStream fileStream = new FileStream(filepath, FileMode.Create);

        // Get the audio clip's data
        float[] samples = new float[clip.samples];
        clip.GetData(samples, 0);

        // Convert the float data to 16-bit integer data and write it to the file
        short[] intData = new short[samples.Length];
        byte[] bytesData = new byte[samples.Length * 2];
        for (int i = 0; i < samples.Length; i++)
        {
          intData[i] = (short)(samples[i] * 32767f);
          byte[] byteArr = new byte[2];
          byteArr = System.BitConverter.GetBytes(intData[i]);
          byteArr.CopyTo(bytesData, i * 2);
        }
        fileStream.Write(bytesData, 0, bytesData.Length);

        // Write the WAV file header
        fileStream.Seek(0, SeekOrigin.Begin);
        byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);

        byte[] chunkSize = System.BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);

        byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);

        byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);

        byte[] subChunk1 = System.BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);

        UInt16 one = 1;
        byte[] audioFormat = System.BitConverter.GetBytes(one);
        fileStream.Write(audioFormat, 0, 2);

        UInt16 channels = (ushort)clip.channels;
        byte[] numChannels = System.BitConverter.GetBytes(channels);
        fileStream.Write(numChannels, 0, 2);

        byte[] sampleRate = System.BitConverter.GetBytes(clip.frequency);
        fileStream.Write(sampleRate, 0, 4);

        byte[] byteRate = System.BitConverter.GetBytes(clip.frequency * channels * 2);
        fileStream.Write(byteRate, 0, 4);

        UInt16 blockAlign = (ushort)(channels * 2);
        fileStream.Write(System.BitConverter.GetBytes(blockAlign), 0, 2);

        UInt16 bps = 16;
        byte[] bitsPerSample = System.BitConverter.GetBytes(bps);
        fileStream.Write(bitsPerSample, 0, 2);

        byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(datastring, 0, 4);

        byte[] subChunk2 = System.BitConverter.GetBytes(samples.Length * channels * 2);
        fileStream.Write(subChunk2, 0, 4);

        // Close the file stream
        fileStream.Close();
      }
    }
  }
}
