using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject frontPlayer;
    [SerializeField] private GameObject sidePlayer;
    [SerializeField] private float speed;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private float growingSpeed;

    private Rigidbody2D _frontPlayerRB;
    private Rigidbody2D _sidePlayerRB;
    private float _moveDir;
    private float _verticalDir;

    private void Awake()
    {
        _frontPlayerRB = frontPlayer.GetComponent<Rigidbody2D>();
        _sidePlayerRB = sidePlayer.GetComponent<Rigidbody2D>();
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
    }
}
