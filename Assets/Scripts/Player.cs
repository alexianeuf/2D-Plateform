using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    private CharacterController _controller;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;
    
    private float _yVelocity;
    private bool _canDoubleJump;

    private int _coins = 0;
    [SerializeField] private int _lives = 3;

    private UiManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();

        if (_controller == null)
        {
            Debug.LogError("The Character Controller is NULL.");
        }

        if (_uiManager == null)
        {
            Debug.LogError("The Ui Manger of the Canvas is NULL.");
        }
        
        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (_canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            _yVelocity -= _gravity; 
        }

        velocity.y = _yVelocity;

        _controller.Move(Time.deltaTime * velocity);
    }

    public void AddCoin(int coin)
    {
        _coins += coin;
        _uiManager.UpdateCoinDisplay(_coins);
    }
    
    // TODO : find when fall, respawn at start, loose a life
    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }
}