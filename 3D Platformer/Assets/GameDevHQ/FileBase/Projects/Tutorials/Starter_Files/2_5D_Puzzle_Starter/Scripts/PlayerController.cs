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
    private bool _jumping = false;
    [SerializeField] Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_controller.enabled == true)
        {
            PlayerMovement();
        }
        
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

            if (_jumping)
            {
                _jumping = false;
                _anim.SetBool("IsJumping", _jumping);
            }

            if (horizontalInput != 0)
            {
                Vector3 facingDirection = transform.localEulerAngles;
                facingDirection.y = _direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facingDirection;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
                _jumping = true;
                _anim.SetBool("IsJumping", _jumping);
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


    public void GrabbingLedge(Vector3 handPosition)
    {
        _anim.SetBool("LedgeGrab", true);
        //_gravity = 0;
        //_yVelocity = 0;

        _controller.enabled = false;
        transform.position = handPosition;
        Debug.Log("Grabbing ledge");
    }


}
