using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.09f;
    private Vector3 _userInput;

    private Rigidbody2D _rigidbody2D;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _userInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
       // transform.position = transform.position + (_userInput.normalized * _speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + (_userInput.normalized * _speed * Time.deltaTime));
    }
}
