using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 _moveDir;

    private void Update()
    {
        transform.Translate(_moveDir* speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext obj)
    {
        _moveDir = obj.ReadValue<Vector2>();
    }
}
