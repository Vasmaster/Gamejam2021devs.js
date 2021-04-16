using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentCharacter : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private PlayerController controller;

    void Start()
    {
        characterImage.color = controller.colors.GetColor(0);
        controller.onChangeCharacter += ControllerOnChangeCharacter;
    }

    private void ControllerOnChangeCharacter(object sender, PlayerController.onChangeEventArgs e)
    {
         characterImage.color = controller.colors.GetColor(e.index);
    }
}
