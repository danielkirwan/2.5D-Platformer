using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] float _speed;
    [SerializeField] float _gravity;
    [SerializeField] float _jumpHeight;
    private float _yVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalMovement, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}