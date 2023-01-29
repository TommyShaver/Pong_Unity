using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _speedUp = 0;
    public Rigidbody2D _rb;
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        if(_speedUp == 5)
        {
            _speed++;
            _speedUp = 0;
            Debug.Log("Speed Up Complete");
            Launch();
        }
    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        _rb.velocity = new Vector2(_speed * x, _speed * y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Padel"))
        {
            _speedUp++;
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            ResetGame();
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
