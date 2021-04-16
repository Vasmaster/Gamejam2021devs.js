using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [HideInInspector] public List<GameObject> playersInGame;

    public int characterIndex = 0;

    void Awake()
    {
        foreach (Transform point in spawnPoints)
        {
            GameObject player = Instantiate(playerPrefab, point.position, Quaternion.identity);
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
    }

    public void OnChange(InputAction.CallbackContext obj)
    {
        if (obj.phase != InputActionPhase.Started) return;
        characterIndex += (int) obj.ReadValue<float>();
        if (characterIndex >= playersInGame.Count) characterIndex = 0;
        SetActiveCharacter(characterIndex);
    }
}
