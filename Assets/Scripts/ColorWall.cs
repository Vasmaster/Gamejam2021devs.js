using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour
{
    [SerializeField] private CharacterColor basicColor;
    [SerializeField] private int colorIndex;
    [SerializeField] private Color _color;

    private SpriteRenderer _sprite;

    private void Start()
    {
        _color = basicColor.GetColor(colorIndex);
        _sprite = transform.GetComponent<SpriteRenderer>();
        _sprite.color = _color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CharacterColor.CompareColor(_sprite.color, collision.transform.Find("Body").GetComponent<SpriteRenderer>().color))
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<BoxCollider2D>(), transform.GetComponent<BoxCollider2D>());
        }
    }
}
