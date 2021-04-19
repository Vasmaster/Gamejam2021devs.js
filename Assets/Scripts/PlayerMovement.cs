using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject frontPlayer;
    [SerializeField] private GameObject sidePlayer;

    public float speed;
    private Rigidbody2D frontPlayerRB;
    private Rigidbody2D sidePlayerRB;
    private float _moveDir;
    private float _verticalDir;

    private void Awake()
    {
        frontPlayerRB = frontPlayer.GetComponent<Rigidbody2D>();
        sidePlayerRB = sidePlayer.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        frontPlayerRB.velocity = transform.right * Time.deltaTime * _moveDir * speed;
        sidePlayerRB.velocity = new Vector2(_moveDir, _verticalDir) * Time.deltaTime * speed;
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
