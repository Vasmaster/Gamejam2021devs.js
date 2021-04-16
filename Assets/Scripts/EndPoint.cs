using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public CharacterColor neededColor;
    [SerializeField] private PlayerController controller;

    private int _colorIndex = 0;

    public event EventHandler<onDeliverColorEventArgs> onDeliverColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.transform.Find("Body").GetComponent<SpriteRenderer>().color == neededColor.GetColor(_colorIndex))
        {
            _colorIndex++;
            controller.destroyedCharacter++;
            controller.playersInGame.Remove(collision.gameObject);
            controller.SetActiveCharacter(0);
            Destroy(collision.gameObject);
            onDeliverColor.Invoke(this, new onDeliverColorEventArgs { index = _colorIndex });
        }
    }

    public class onDeliverColorEventArgs : EventArgs
    {
        public int index;
    }
}
