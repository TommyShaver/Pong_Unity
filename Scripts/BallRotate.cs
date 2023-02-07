using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotate : MonoBehaviour
{
    public float _speed;
    // Start is called before the first frame update
  
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _speed); 
    }

    public void RessetBall()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(0.5f, .5f, 1);
    }
}
