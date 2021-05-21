using System.Collections;                                    //Mitchel Wingelaar
using System.Collections.Generic;                                 // klas 1c1
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name);

        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager?.StartGame(difficulty);
    }
}
