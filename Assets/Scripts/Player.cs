using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Pawn[] pawns;
    [SerializeField] private Dice dice;

    bool waitForRoll = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press Space to roll the dice");
        dice = GameObject.Find("Dice").GetComponent<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForRoll && Input.GetKeyDown(KeyCode.Space)){
            int diceNumber = dice.RollDice();
            Debug.Log("Dice: " + diceNumber);
            dice.updateRender(diceNumber);
            waitForRoll = dice.checkifRollisSix(diceNumber);
        }

        if (!waitForRoll && Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("You can't roll the dice anymore");
        }
    }
}
