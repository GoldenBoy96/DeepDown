using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

public class DataManager
{
    

    public static GameData GetGameData()
    {        
        return ReadData();
    }

    public static void SetGameData(GameData _gameData)
    {        
        SaveData(_gameData);
    }

    private static GameData ReadData()
    {
        GameData _gameData;
        string jsonRead;
        try
        {
            jsonRead = System.IO.File.ReadAllText("data.txt");
            _gameData = JsonUtility.FromJson<GameData>(jsonRead);
        }
        catch (FileNotFoundException)
        {
            _gameData = new GameData();
            string json = JsonUtility.ToJson(_gameData);
            System.IO.File.WriteAllText("data.txt", json);
        }
        return _gameData;
    }

    private static void SaveData(GameData _gameData)
    {
        string json = JsonUtility.ToJson(_gameData);
        //Debug.Log(json);
        System.IO.File.WriteAllText("data.txt", json);
    }
}
