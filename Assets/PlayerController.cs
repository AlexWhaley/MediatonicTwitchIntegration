using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private bool _isInitialised = false;
    private PlayerControls _playerControls;
    private Rigidbody2D _playerRB;

    [SerializeField] private float _playerSpeed = 1.0f;
    [SerializeField] private SpriteRenderer _playerSprite;


    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    public void InitialisePlayer(PlayerConfig playerConfig)
    {
        _isInitialised = true;
        _playerControls = playerConfig.PlayerControls;
        _playerSprite.color = playerConfig.PlayerColor;

    }

    public void FixedUpdate()
    {
        if (!_isInitialised)
        {
            return;
        }

        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        var _playerVel = new Vector2(0.0f, 0.0f);
        if (Input.GetKeyDown(_playerControls.UpKey))
        {
            _playerVel.y += _playerSpeed;
        }
        if (Input.GetKeyDown(_playerControls.DownKey))
        {
            _playerVel.y -= _playerSpeed;
        }
        if (Input.GetKeyDown(_playerControls.RightKey))
        {
            _playerVel.x += _playerSpeed;
        }
        if (Input.GetKeyDown(_playerControls.LeftKey))
        {
            _playerVel.x -= _playerSpeed;
        }

        _playerRB.velocity = _playerVel;
    }
}

public struct PlayerConfig
{
    public PlayerControls PlayerControls;
    public Color PlayerColor;
}

public struct PlayerControls
{
    public string UpKey;
    public string DownKey;
    public string LeftKey;
    public string RightKey;
}
