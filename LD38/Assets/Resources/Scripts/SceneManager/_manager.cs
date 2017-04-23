using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class _manager : MonoBehaviour {

    public float _timer = 30.0f;
    public float _maxTime = 30.0f;
    public int _cratesRemaining;
    public Text _timerTxt;
    public Text _cratesRemainingTxt;
    public bool _inMenu;
    public GameObject _winScreen;
    public GameObject _loseScreen;
    public Text _countdownTxt;
    public bool _gameOver;
    public float _countdown = 3.0f;
    public Text _timeTakenText;

	// Use this for initialization
	void Start () {
        _timer = _maxTime;
        _inMenu = true;
        _winScreen = GameObject.Find("GameOver_win");
        _winScreen.SetActive(false);
        _loseScreen = GameObject.Find("GameOver_lose");
        _loseScreen.SetActive(false);
        _timeTakenText = GameObject.Find("TimeTakenTxt").GetComponent<Text>();
        _timeTakenText.enabled = false;
        _countdownTxt = GameObject.Find("CountdownTxt").GetComponent<Text>();
        _timerTxt = GameObject.Find("TimerTxt").GetComponent<Text>();
        _cratesRemainingTxt = GameObject.Find("CratesRemainingTxt").GetComponent<Text>();
        _cratesRemaining = GameObject.FindGameObjectsWithTag("Crate").Length;
        _cratesRemainingTxt.text = _cratesRemaining.ToString();
        _timerTxt.text = _timer.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (_inMenu && !_gameOver)
        {
            Countdown();
            return;
        }
        if (!_gameOver) UpdateTimer();
	}

    void UpdateTimer()
    {
        _timer -= Time.deltaTime;
        var time = Mathf.CeilToInt(_timer);
        _timerTxt.text = time.ToString();
        if (_timer <= 0.0f)
        {
            EndLevel(false);
        }
    }

    void Countdown()
    {
        _countdown -= Time.deltaTime;
        var time = Mathf.CeilToInt(_countdown);
        if (_countdown <= 0.0f)
        {
            _countdownTxt.text = "GO!";
            _countdownTxt.fontSize = 150;
            _inMenu = false;
            StartCoroutine(CloseCountdown());
        }
        else 
        {
            _countdownTxt.text = time.ToString();
        }
    }

    public void UpdateCrates()
    {
        _cratesRemaining--;
        _cratesRemainingTxt.text = _cratesRemaining.ToString();
        if (_cratesRemaining == 0) EndLevel(true);
    }

    public IEnumerator CloseCountdown()
    {
        yield return new WaitForSeconds(1.2f);
        _countdownTxt.enabled = false;
    }

    public void EndLevel(bool victory)
    {
        _inMenu = true;
        _gameOver = true;
        if (victory)
        {
            _winScreen.SetActive(true);
            if (_playerManager._playerLevel < SceneManager.GetActiveScene().buildIndex) _playerManager._playerLevel = SceneManager.GetActiveScene().buildIndex;
            var time = (_maxTime - _timer).ToString("F2");
            _timeTakenText.text = "Completed in: " + time + "s";
            _timeTakenText.enabled = true;
        }
        else
        {
            _loseScreen.SetActive(true);
        }               
    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
