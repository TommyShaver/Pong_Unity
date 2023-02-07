using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _leftScoreText, _rightScoreText;
    public GameObject _pauseScreen, _titleScreen, _player2Button, _computerButton, _easyButton, _medButton, _hardButton;
    
    public bool _paused, _gameIsLive = false, _winner;

    private int _leftScoreNumber, _rightScoreNumber;
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _gameIsLive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GameObject.Find("Control 2").GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePause();
        }
    }
    public void UpdateScoreLeft(int scoreToAdd)
    {
        _rightScoreNumber += scoreToAdd;
        _rightScoreText.text = " " + _rightScoreNumber;
        if(_rightScoreNumber == 10)
        {
            _winner = true;
        }
    }
    public void UpdateScoreRight(int scoreToAdd)
    {
        _leftScoreNumber += scoreToAdd;
        _leftScoreText.text = " " + _leftScoreNumber;
        if (_leftScoreNumber == 10)
        {
            _winner = true;
        }
    }
    void ChangePause()
    {
        if(!_paused)
        {
            _paused = true;
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _paused = false;
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Player2Button()
    {
        _playerMovement._isplayer2 = true;
        _gameIsLive = true;
        _titleScreen.SetActive(false);
        _player2Button.SetActive(false);
    }
    public void ComputerSelect()
    {
        _player2Button.SetActive(false);
        _playerMovement._isplayer2 = false;
        _easyButton.SetActive(true);
        _medButton.SetActive(true);
        _hardButton.SetActive(true);
    }
    public void EasyAI()
    {
        _gameIsLive = true;
        _titleScreen.SetActive(false);
        TurnOffButton();
        _playerMovement._easyAI = true;
    }
    public void MedieumAI()
    {
        _gameIsLive = true;
        _titleScreen.SetActive(false);
        TurnOffButton();
        _playerMovement._mediumAI = true;
    }
    public void HardAI()
    {
        _gameIsLive = true;
        _titleScreen.SetActive(false);
        TurnOffButton();
        _playerMovement._hardAI = true;
    }
    private void TurnOffButton()
    {
        _easyButton.SetActive(false);
        _medButton.SetActive(false);
        _hardButton.SetActive(false);
        _computerButton.SetActive(false);
    }
}
