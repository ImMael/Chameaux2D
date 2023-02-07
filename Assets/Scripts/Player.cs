using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Pawn[] pawns;

    bool waitForRoll = true;

    int RollDice(){          
        int dice = Random.Range(1, 7);
        return dice;
    }

    bool checkifRollisSix(int dice){
        return dice == 6 ? true : false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press Space to roll the dice");
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForRoll && Input.GetKeyDown(KeyCode.Space)){
            int dice = RollDice();
            Debug.Log("Dice: " + dice);
            waitForRoll = checkifRollisSix(dice);
        }

        if (!waitForRoll && Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("You can't roll the dice anymore");
        }
    }
}
