using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CharacterColor colors;
    public CharacterColor currentColors;
    [SerializeField] private Transform[] spawnPoints;
     public List<GameObject> playersInGame;
     public int characterIndex = 0;

    public event EventHandler<onChangeEventArgs> onChangeCharacter;

    void Start()
    {
        currentColors.Setup();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);
            player.transform.Find("Body").GetComponent<SpriteRenderer>().color = colors.GetColor(i);
            playersInGame.Add(player);
            currentColors.AddColor(colors.GetColor(i));
        }
        SetActiveCharacter(characterIndex);
    }


    public void SetActiveCharacter(int index)
    {
        for (int i = 0; i < playersInGame.Count; i++)
        {
            if (i == index)
            {
                playersInGame[i].GetComponent<PlayerMovement>().enabled = true;
                continue;
            }
            playersInGame[i].GetComponent<PlayerMovement>().enabled = false;
        }
        onChangeCharacter?.Invoke(this, new onChangeEventArgs { index = characterIndex});
    }

    public void OnChange(InputAction.CallbackContext obj)
    {
        if (obj.phase != InputActionPhase.Started) return;
        characterIndex += (int) obj.ReadValue<float>();
        if (characterIndex >= playersInGame.Count) characterIndex = 0;
        if (characterIndex < 0) characterIndex = playersInGame.Count - 1;
        
        SetActiveCharacter(characterIndex);
    }

    public class onChangeEventArgs : EventArgs
    {
        public int index;
    }
}
