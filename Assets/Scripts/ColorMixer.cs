using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    [SerializeField] private ColorMixingData colorMixing;
    [SerializeField] private SpriteRenderer firstColorImage;
    [SerializeField] private SpriteRenderer secondColorImage;
    [SerializeField] private PlayerController controller;

    private bool _firstSet = false;
    private Color _firstColor;
    private Color _secondColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!_firstSet)
            {
                _firstColor = collision.transform.Find("Body").GetComponent<SpriteRenderer>().color;
                firstColorImage.color = _firstColor;
                _firstSet = true;
                controller.playersInGame.Remove(collision.gameObject);
                controller.currentColors.RemoveColor(_firstColor);
                //controller.characterIndex = 0;
                controller.SetActiveCharacter(0);
                Destroy(collision.gameObject);
            }
            else
            {
                _secondColor = collision.transform.Find("Body").GetComponent<SpriteRenderer>().color;
                secondColorImage.color = _secondColor;
                Color newColor = colorMixing.SearchMixColor(_firstColor, _secondColor);
                if (newColor != new Color(0, 0, 0))
                {
                    int colorIndex = controller.currentColors.FindColorIndex(collision.transform.Find("Body").GetComponent<SpriteRenderer>().color);
                    collision.transform.Find("Body").GetComponent<SpriteRenderer>().color = newColor;
                    controller.currentColors.SetColor(colorIndex, newColor);
                    controller.SetActiveCharacter(colorIndex);
                }
            }
            
        }
    }
}
