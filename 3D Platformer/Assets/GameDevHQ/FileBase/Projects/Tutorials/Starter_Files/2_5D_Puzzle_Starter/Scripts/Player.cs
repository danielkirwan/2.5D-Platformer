using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;
    private bool _wallJump = false;
    private Vector3 _wallJumpSurfaceNormal;
    private Vector3 _direction, _velocity;
    [SerializeField] float _pushPower;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        

        if (!_wallJump)
        {
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;
        }

        if (_controller.isGrounded == true)
        {
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;
            _wallJump = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_wallJump)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            if(Input.GetKeyDown(KeyCode.Space) && _wallJump)
            {
                _yVelocity = _jumpHeight;
                _velocity = _wallJumpSurfaceNormal * _speed;
            }

            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!_controller.isGrounded && hit.transform.CompareTag("Wall"))
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallJumpSurfaceNormal = hit.normal;
            _wallJump = true;
        }

        if (hit.transform.CompareTag("MoveableBox"))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            //no rigidbody
            if (rb == null || rb.isKinematic) return;
            //don't push objects below us
            if (hit.moveDirection.y < -0.3f) return;
            //calculate push direction from move direction
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);

            //apply the push
            rb.velocity = pushDir * _pushPower;
        }

    }

    public void AddCoins()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int ReturnCoins()
    {
        return _coins;
    }
}
