using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public CharacterColor colors;
    [SerializeField] private Transform[] spawnPoints;
     public List<GameObject> playersInGame;
     public int characterIndex = 0;
    [HideInInspector] public int destroyedCharacter = 0;

    public event EventHandler<onChangeEventArgs> onChangeCharacter;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);
            player.transform.Find("Body").GetComponent<SpriteRenderer>().color = colors.GetColor(i);
            playersInGame.Add(player);
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
        onChangeCharacter.Invoke(this, new onChangeEventArgs { index = characterIndex + destroyedCharacter});
    }

    public void OnChange(InputAction.CallbackContext obj)
    {
        if (obj.phase != InputActionPhase.Started) return;
        characterIndex += (int) obj.ReadValue<float>();
        if (characterIndex - destroyedCharacter >= playersInGame.Count) characterIndex = destroyedCharacter;
        if (characterIndex - destroyedCharacter < 0) characterIndex = playersInGame.Count - 1 + destroyedCharacter;
        
        SetActiveCharacter(characterIndex - destroyedCharacter);
    }

    public class onChangeEventArgs : EventArgs
    {
        public int index;
    }
}
