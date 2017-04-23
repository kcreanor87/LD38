using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public List<Button> _buttons = new List<Button>();
    public List<GameObject> _worlds = new List<GameObject>();
    public GameObject _intro;
    public GameObject _worldcontainer;
    public GameObject _levelSelect;
    public Sprite _mute;
    public Sprite _unmute;
    public Image _muteBtn;

    public Text _bestTimeTxt;

    public int _levelSelected;

	// Use this for initialization
	void Start () {
        _muteBtn = GameObject.Find("Mute").GetComponent<Image>();
        _muteBtn.sprite = (AudioListener.pause == true) ? _unmute : _mute;
        _bestTimeTxt = GameObject.Find("BestTimeTxt").GetComponent<Text>();
        _bestTimeTxt.text = "Record: " + _playerManager._times[_playerManager._playerLevel].ToString("F2") + "s";
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].interactable = (i <= _playerManager._playerLevel);
        }
        SelectLevel(_playerManager._playerLevel);
        _levelSelect.SetActive(false);
        _worldcontainer.SetActive(false);
    }

    public void SelectLevel(int i)
    {
        _levelSelected = i;
        for (int j = 0; j < _worlds.Count; j++) {
            _worlds[j].SetActive(i == j);
        }
        _bestTimeTxt.text = "Record: " + _playerManager._times[i].ToString("F2") + "s";
    }

    public void OpenLevelSelect()
    {
        _intro.SetActive(false);
        _levelSelect.SetActive(true);
        _worldcontainer.SetActive(true);
        SelectLevel(_playerManager._playerLevel);
    }

    public void Play()
    {
        SceneManager.LoadScene(_levelSelected + 2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
        _muteBtn.sprite = (AudioListener.pause == true) ? _unmute : _mute;
    }
}
