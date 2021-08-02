using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private Vector3 _direction, _velocity;
    private bool _canDoubleJump = false;
    [SerializeField] Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (_controller.isGrounded == true)
        {
            _direction = new Vector3(0, 0, horizontalInput);
            _velocity = _direction * _speed;
            //_wallJump = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
                _anim.SetTrigger("IsJumping");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _anim.SetTrigger("IsDoubleJump");
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }
        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);
    }

}
