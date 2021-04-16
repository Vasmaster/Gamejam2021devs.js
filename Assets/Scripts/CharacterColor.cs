using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Character/Colors")]
public class CharacterColor : ScriptableObject
{
    [SerializeField] private List<Color> colors;

    public Color GetColor(int index)
    {
        return colors[index];
    }

    public int FindColorIndex(Color otherColor)
    {
        string colorHex = ColorUtility.ToHtmlStringRGB(otherColor);
        for (int i = 0; i < colors.Count; i++)
        {
            if (ColorUtility.ToHtmlStringRGB(colors[i]).Equals(colorHex)) return i;
        }
        return -1;
    }

    public void SetColor(int index, Color color)
    {
        colors[index] = color;
    }

    public void AddColor(Color color)
    {
        colors.Add(color);
    }

    public void RemoveColor(Color color)
    {
        colors.Remove(color);
    }

    public void Setup()
    {
        colors.Clear();
    }

    public static bool CompareColor(Color color1, Color color2)
    {
        string color1Hex = ColorUtility.ToHtmlStringRGB(color1);
        string color2Hex = ColorUtility.ToHtmlStringRGB(color2);
        if (color1Hex == color2Hex) return true;
        return false;
    }
}
