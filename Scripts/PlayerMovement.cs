using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _aiSpeed;
    [SerializeField] float _yRange;
    [SerializeField] Vector2 _forwardDirection;
    public bool _isplayer1;
    public bool _isplayer2;
    public bool _easyAI;
    public bool _mediumAI;
    public bool _hardAI;

    private BallMovement _ball;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
        if(_easyAI == true)
        {
            _aiSpeed = 5;
            _forwardDirection = Vector2.left;
            Debug.Log("its easy");
        }
        if (_mediumAI == true)
        {
            _aiSpeed = 15;
            _forwardDirection = Vector2.left;
            Debug.Log("its med");
        }
        if (_hardAI == true)
        {
            _aiSpeed = 20;
            _forwardDirection = Vector2.left;
            Debug.Log("its hard");
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerOne();
        PlayerTwo();
        PlayerAI();
    }

    void PlayerOne()
    {
        //Keep In Bounds
        if (transform.position.y < -_yRange)
        {
            transform.position = new Vector2(transform.position.x, -_yRange);
        }
        if (transform.position.y > _yRange)
        {
            transform.position = new Vector2(transform.position.x, _yRange);
        }

        //Movement
        if (Input.GetKey(KeyCode.W) && transform.position.y >= -3.8 && _isplayer1 == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y <= 3.8 && _isplayer1 == true)
        {
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
    }
    void PlayerTwo()
    {
        //Keep In Bounds
        if (transform.position.y < -_yRange)
        {
            transform.position = new Vector2(transform.position.x, -_yRange);
        }
        if (transform.position.y > _yRange)
        {
            transform.position = new Vector2(transform.position.x, _yRange);
        }

        //Movement
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y >= -3.8 && _isplayer2 == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y <= 3.8 && _isplayer2 == true)
        {
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
    }
    void PlayerAI()
    {
        //Keep In Bounds
        if (transform.position.y < -_yRange)
        {
            transform.position = new Vector2(transform.position.x, -_yRange);
        }
        if (transform.position.y > _yRange)
        {
            transform.position = new Vector2(transform.position.x, _yRange);
        }

        float targetYPostion = GetNewYPostion();
        transform.position = new Vector3(transform.position.x, targetYPostion, transform.position.z);
    }
    private float GetNewYPostion()
    {
        float _result = transform.position.y;
        if(BallIncoming())
        {
            _result = Mathf.MoveTowards(transform.position.y, _ball.transform.position.y, _aiSpeed * Time.deltaTime);
          
        }
        return _result;
    }
    private bool BallIncoming()
    {
        float _dotP = Vector2.Dot(_ball._rb.velocity, _forwardDirection);
        return _dotP < 0f;
    }
}
