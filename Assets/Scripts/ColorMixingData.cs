using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Color mixer")]
public class ColorMixingData : ScriptableObject
{
    [Serializable]
    public class ColorMixer
    {
        public Color inputColor1;
        public Color inputColor2;
        public Color outputColor;
    }

    public ColorMixer[] colors;

    public Color SearchMixColor(Color first, Color second)
    {
        string firstHex = ColorUtility.ToHtmlStringRGB(first);
        string secondHex = ColorUtility.ToHtmlStringRGB(second);
        foreach (ColorMixer color in colors)
        {
            if( ColorUtility.ToHtmlStringRGB(color.inputColor1).Equals(firstHex) && ColorUtility.ToHtmlStringRGB(color.inputColor2).Equals(secondHex)) return color.outputColor;
            if( ColorUtility.ToHtmlStringRGB(color.inputColor1).Equals(secondHex) && ColorUtility.ToHtmlStringRGB(color.inputColor2).Equals(firstHex)) return color.outputColor;
        }
        return new Color(0, 0, 0);
    }
}
