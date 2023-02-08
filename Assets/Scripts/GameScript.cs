using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    readonly Position RED_SPAWN_POSITION = new Position((float)3, (float)6, (float)-1);
    readonly Position YELLOW_SPAWN_POSITION = new Position((float)3, (float)-3, (float)-1);
    readonly Position GREEN_SPAWN_POSITION = new Position((float)-3, (float)-3, (float)-1);
    readonly Position BLUE_SPAWN_POSITION = new Position((float)-3, (float)6,(float)-1);

    const int RED_START_CASE = 0;
    const int YELLOW_START_CASE = 14;
    const int GREEN_START_CASE = 28;
    const int BLUE_START_CASE = 42;

    bool isGameRunning = false;
    int startingPlayer = 0;

    [SerializeField] Case[] cases;
    [SerializeField] Player[] players;

    

    public void startTurn(Player player) {
        int dice = player.RollDice();
        if(player.getPawns()[0].isPawnInSpawn) {
            if(player.checkifRollisSix(dice)) {
                movePawnToStartCase(player);
            } else {
                player.getPawns()[0].callNot6();
            }
        } else {
            movePawn(player, dice);
        }

        Debug.Log(player + " rolled: " + dice);
        getStartingPlayer();
    }

    public void getStartingPlayer() {
        if(startingPlayer < players.Length - 1) {
            startingPlayer++;
        } else {
            startingPlayer = 0;
        }
    }

    public void movePawnToStartCase(Player player) {
        player.getPawns()[0].moveToCase(cases[player.startPosition]);
        player.currentPosition = player.startPosition;
        player.getPawns()[0].isPawnInSpawn = false;
    }

    public void movePawn(Player player, int dice) {
        cases[player.currentPosition].clearCase();
        int newPosition = player.currentPosition + dice;
        if(newPosition > 55) {
            newPosition = newPosition - 56;
        }
        if(cases[newPosition].hasPawn) {
            cases[newPosition].pawn.moveToSpawn();
            cases[newPosition].pawn.isPawnInSpawn = true;
            player.getPawns()[0].moveToCase(cases[newPosition]);
            player.currentPosition = newPosition;
        } else {
            player.getPawns()[0].moveToCase(cases[newPosition]);
            player.currentPosition = newPosition;
        }
    }


    // Start is called before the first frame update
    void Start() 
    {
        Debug.Log("Press space to start the game");
        isGameRunning = true;

        players[0].startPosition = RED_START_CASE;
        players[0].Color = "Red";
        players[0].spawnPosition = RED_SPAWN_POSITION;

        players[1].startPosition = YELLOW_START_CASE;
        players[1].Color = "Yellow";
        players[1].spawnPosition = YELLOW_SPAWN_POSITION;

        players[2].startPosition = GREEN_START_CASE;
        players[2].Color = "Green";
        players[2].spawnPosition = GREEN_SPAWN_POSITION;

        players[3].startPosition = BLUE_START_CASE;
        players[3].Color = "Blue";
        players[3].spawnPosition = BLUE_SPAWN_POSITION;
    }

    // Update is called once per frame
    void Update()
    {

        if(isGameRunning) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                startTurn(players[startingPlayer]);
                Debug.Log(" ----------------- ");
            }
        }
       
    }

}



// for(int i = 0; i < players.Length; i++){
        //     bool currentPlayerCanPlay = true;
        //     Player currentPlayer = players[i];
        //     Debug.Log("Player " + i + " is playing");
        //     bool firstRoll = true;
        //     while(currentPlayerCanPlay) {
        //         Debug.Log("first roll: " + firstRoll);
        //         if(Input.GetKeyDown(KeyCode.Space)) {
        //             int dice = currentPlayer.RollDice();
        //             Debug.Log("Dice rolled: " + dice);
        //             if(firstRoll && !currentPlayer.checkifRollisSix(dice)) {
        //                 currentPlayer.getPawns()[0].callNot6();
        //                 currentPlayerCanPlay = false;
        //             }
        //             else {
        //                 currentCaseIndex += dice;
        //                 currentPlayer.getPawns()[0].moveToCase(cases[currentCaseIndex]);
        //                 currentPlayerCanPlay = currentPlayer.checkifRollisSix(dice);
        //                 if(currentPlayer.checkifRollisSix(dice)) {
        //                     firstRoll = false;
        //                     }
        //                 }
        //             }
        //         }
        //         Debug.Log("Player " + i + " has finished his turn");
        //     }