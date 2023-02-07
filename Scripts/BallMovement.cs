using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _speedUp = 0;
    [SerializeField] bool _gameOver = true;
    public GameObject _ball, _CountDownTimer, _leftGoal, _rightGoal, _winnerText;
    public Rigidbody2D _rb;

    Coroutine _launchTimer;

    private GameManager _gameManger;
    private BallRotate _ballRotate;

    private void Awake()
    {
        _gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver == true && _gameManger._gameIsLive == true)
        {
            StartTheGame();
        }
        if (_speedUp == 5)
        {
            _speed++;
            _speedUp = 0;
            Debug.Log("Speed Up Complete");
            Launch();
        }
        ResetGame();
        if(_gameManger._winner == true)
        {
            _winnerText.SetActive(true);
        }
    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        _rb.velocity = new Vector2(_speed * x, _speed * y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Padel"))
        {
            _speedUp++;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal Left"))
        {
            _gameManger.UpdateScoreRight(1);
            ResetBallPosition();
            if(!_gameManger._winner)
            {
                _leftGoal.SetActive(true);
                _launchTimer = StartCoroutine(LunachTimer(3));
            }
            
  
        }
        if (other.gameObject.CompareTag("Goal Right"))
        {
            _gameManger.UpdateScoreLeft(1);
            ResetBallPosition();
            if(!_gameManger._winner)
            {
                _rightGoal.SetActive(true);
                _launchTimer = StartCoroutine(LunachTimer(3));
            }
            
        }
    }
    public void ResetGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void ResetBallPosition()
    {
        _ball.transform.position = new Vector2(0 , 0);
        _rb.velocity = new Vector2(0, 0);
    }    
    
    IEnumerator LunachTimer(int _countTimer)
    {
       
        _ballRotate._speed = 240;
        _CountDownTimer.SetActive(true);
        int i = 0;
        while(i < _countTimer)
        {
            i++;
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        _ballRotate._speed = 0;
        _ballRotate.RessetBall();
        _CountDownTimer.SetActive(false);
        _leftGoal.SetActive(false);
        _rightGoal.SetActive(false);
        Launch();
        Debug.Log("Finished");
    }
    void StartTheGame()
    {
        _ballRotate = GetComponent<BallRotate>();
        _launchTimer = StartCoroutine(LunachTimer(3));
        _gameOver = false;
    }
}
