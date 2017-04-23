using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _playerManager : MonoBehaviour {

    public static int _playerLevel;

    public static List<float> _times = new List<float>();

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey("PlayerLevel")){
            PlayerPrefs.SetInt("PlayerLevel", 0);
            for (int i = 0; i < 12; i++)
            {
                PlayerPrefs.SetFloat("Time" + i, 0.0f);
                print(PlayerPrefs.GetFloat("Time" + i));
            }
        }
        else {
            _playerLevel = PlayerPrefs.GetInt("PlayerLevel");
            if (_playerLevel == 12) _playerLevel = 11;
            for (int i = 0; i < 12; i++)
            {
                _times.Add(0.0f);
            }
            LoadTimes();
        }
    }

    public static void SaveTimes()
    {
        for (int i = 0; i < _times.Count; i++)
        {
            PlayerPrefs.SetFloat("Time" + i, _times[i]);
        }
    }

    void LoadTimes()
    {
        for (int i = 0; i < _times.Count; i++)
        {
            _times[i] = PlayerPrefs.GetFloat("Time" + i);
        }
    }
}
