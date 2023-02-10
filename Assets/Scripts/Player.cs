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

    public bool checkifPawnIsInSpawn(Pawn pawn){
        return pawn.isPawnInSpawn;
    }

    public bool checkIfAnyPawnIsInSpawn(){
        bool anyPawnInSpawn = false;
        foreach(Pawn pawn in pawns) {
            if(pawn.isPawnInSpawn) {
                anyPawnInSpawn = true;
            }
        }
        return anyPawnInSpawn;
    }

    public bool checkifAllPawnsAreInSpawn(){
        bool allPawnsInSpawn = true;
        foreach(Pawn pawn in pawns) {
            if(!pawn.isPawnInSpawn) {
                allPawnsInSpawn = false;
            }
        }
        return allPawnsInSpawn;
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
