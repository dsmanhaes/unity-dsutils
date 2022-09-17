using System.IO;
using UnityEngine;

public class PostalController
{
    public static string QRCodePath
    { get { return _configsCache.abspath; } }
    public static string QRCodeURL
    { get { return _configsCache.url; } }

    private static string _path;
    private static QRConfig _configs;
    
    private static QRConfig _configsCache
    {
        get
        {
            if (_configs == null)
            {
                _path = Application.dataPath + "/../../qrcode.json";
                if (File.Exists(_path)) LoadConfig();
                else CreateConfig();
            }
            return _configs;
        }
    }

    private static void LoadConfig ()
    {
        string json = File.ReadAllText(_path);
        _configs = JsonUtility.FromJson<QRConfig>(json);
        if (string.IsNullOrEmpty(_configs.url) || 
            string.IsNullOrEmpty(_configs.abspath))
            CreateConfig();
    }

    private static void CreateConfig ()
    {
        _configs = new QRConfig();
        _configs.url = "https://postal.social/projeto/?";
        _configs.abspath = "C:/Teste/";
        string json = JsonUtility.ToJson(_configs);
        File.WriteAllText(_path, json);
        Debug.Log("Arquivo de configuração criado com sucesso em " + _path);
    }

    [System.Serializable]
    private class QRConfig
    {
        public string url;
        public string abspath;
    }
}
