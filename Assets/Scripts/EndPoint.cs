using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public CharacterColor neededColor;
    [SerializeField] private PlayerController controller;

    [SerializeField] private int _colorIndex = 0;

    public event EventHandler<onDeliverColorEventArgs> onDeliverColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && CharacterColor.CompareColor( collision.transform.Find("Body").GetComponent<SpriteRenderer>().color, neededColor.GetColor(_colorIndex)) )
        {
            controller.currentColors.RemoveColor(neededColor.GetColor(_colorIndex));
            controller.playersInGame.Remove(collision.gameObject);
            controller.characterIndex = 0;
            controller.SetActiveCharacter(0);
            Destroy(collision.gameObject);
            _colorIndex++;
            onDeliverColor.Invoke(this, new onDeliverColorEventArgs { index = _colorIndex });
        }
    }

    public class onDeliverColorEventArgs : EventArgs
    {
        public int index;
    }
}
