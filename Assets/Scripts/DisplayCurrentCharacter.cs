using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentCharacter : MonoBehaviour
{
    [Header("Character Color")]
    [SerializeField] private Image characterImage;
    [SerializeField] private PlayerController controller;
    [Header("Needed Color")]
    [SerializeField] private Image neededColor;
    [SerializeField] private EndPoint endPoint;

    void Start()
    {
        characterImage.color = controller.currentColors.GetColor(0);
        neededColor.color = endPoint.neededColor.GetColor(0);
        controller.onChangeCharacter += ControllerOnChangeCharacter;
        endPoint.onDeliverColor += EndPointOnDeliverColor;
    }

    private void EndPointOnDeliverColor(object sender, EndPoint.onDeliverColorEventArgs e)
    {
        neededColor.color = endPoint.neededColor.GetColor(e.index);
    }

    private void ControllerOnChangeCharacter(object sender, PlayerController.onChangeEventArgs e)
    {
         characterImage.color = controller.currentColors.GetColor(e.index);
    }
}
