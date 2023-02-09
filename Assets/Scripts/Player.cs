using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Pawn[] pawns;
    [SerializeField] private Dice dice;

    public string Color { get; set; }
    public int startPosition { get; set; }
    public int currentPosition { get; set; }
    public Position spawnPosition { get; set; }

    public int RollDice() {
        return dice.RollDice();
    }

    public Pawn[] getPawns() {
        return pawns;
    }

    public bool checkifRollisSix(int currentDice){
        return dice.checkifRollisSix(currentDice);
    }



    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.Find("Dice").GetComponent<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
