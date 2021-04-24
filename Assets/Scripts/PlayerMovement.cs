using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject frontPlayer;
    [SerializeField] private GameObject sidePlayer;
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private float growingSpeed;
    [Header("Sprite")]
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite topFrontSprite;
    [SerializeField] private Sprite topBackSprite;

    private Rigidbody2D _frontPlayerRB;
    private Rigidbody2D _sidePlayerRB;
    private SpriteRenderer _frontPlayerSprite;
    private SpriteRenderer _sidePlayerSprite;
    private float _moveDir;
    private float _verticalDir;

    private void Awake()
    {
        _frontPlayerRB = frontPlayer.GetComponent<Rigidbody2D>();
        _sidePlayerRB = sidePlayer.GetComponent<Rigidbody2D>();
        _frontPlayerSprite = frontPlayer.GetComponent<SpriteRenderer>();
        _sidePlayerSprite = sidePlayer.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _frontPlayerRB.velocity = transform.right * Time.deltaTime * _moveDir * speed;
        _sidePlayerRB.velocity = new Vector2(_moveDir, _verticalDir) * Time.deltaTime * speed;
        if(frontPlayer.transform.localScale.x < maxSize && _verticalDir > 0)
        {
            frontPlayer.transform.localScale += new Vector3(growingSpeed * _verticalDir, growingSpeed * _verticalDir);
        }
        if(frontPlayer.transform.localScale.x > minSize && _verticalDir < 0)
        {
            frontPlayer.transform.localScale += new Vector3(growingSpeed * _verticalDir, growingSpeed * _verticalDir);
        }
    }

    public void OnLeftRight(InputAction.CallbackContext obj)
    {
        _moveDir = obj.ReadValue<float>();
    }

    public void OnUpDown(InputAction.CallbackContext obj)
    {
        _verticalDir = obj.ReadValue<float>();
        ToggleSprite();
    }

    private void ToggleSprite()
    {
        if(_verticalDir < 0)
        {
            _frontPlayerSprite.sprite = backSprite;
            _sidePlayerSprite.sprite = topFrontSprite;
        }
        if(_verticalDir > 0)
        {
            _frontPlayerSprite.sprite = frontSprite;
            _sidePlayerSprite.sprite = topBackSprite;
        }
    }
}
