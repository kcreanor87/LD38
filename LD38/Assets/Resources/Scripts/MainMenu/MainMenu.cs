using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public List<Button> _buttons = new List<Button>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].interactable = i <= _playerManager._playerLevel;
        }
	}

    public void SelectLevel(int i)
    {
        SceneManager.LoadScene(i + 1);
    }
}
