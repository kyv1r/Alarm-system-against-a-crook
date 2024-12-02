using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        float distance = _speed * direction * Time.deltaTime;
        transform.Translate(distance * Vector2.right);        
    }
}
