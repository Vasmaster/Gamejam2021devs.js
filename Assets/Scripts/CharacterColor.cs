using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Character/Colors")]
public class CharacterColor : ScriptableObject
{
    [SerializeField] private Color[] colors;

    public Color GetColor(int index)
    {
        return colors[index];
    }
}
