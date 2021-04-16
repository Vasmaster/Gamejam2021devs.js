using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCurrentCharacter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private PlayerController controller;

    void Start()
    {
        controller.onChangeCharacter += ControllerOnChangeCharacter;
    }

    private void ControllerOnChangeCharacter(object sender, PlayerController.onChangeEventArgs e)
    {
        text.text = e.index.ToString();
    }
}
