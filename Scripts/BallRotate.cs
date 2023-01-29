using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotate : MonoBehaviour
{
    [SerializeField] float _speed;
    // Start is called before the first frame update
  
    private void LateUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _speed);
    }
}
