using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private CharacterColor neededColor;
    [SerializeField] private PlayerController controller;

    public int colorIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.transform.Find("Body").GetComponent<SpriteRenderer>().color == neededColor.GetColor(colorIndex))
        {
            colorIndex++;
            controller.destroyedCharacter++;
            controller.playersInGame.Remove(collision.gameObject);
            controller.SetActiveCharacter(0);
            Destroy(collision.gameObject);
        }
    }
}
