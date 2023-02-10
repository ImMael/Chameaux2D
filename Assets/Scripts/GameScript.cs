using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{

    private TMP_Text textMesh;

    readonly Position[] RED_SPAWN_POSITION = new Position[] {
        new Position((float)3, (float)6, (float)-1),
        new Position((float)5.80, (float)6, (float)-1),
        new Position((float)5.80, (float)3, (float)-1),
        new Position((float)3, (float)3, (float)-1)
    };

    readonly Position[] YELLOW_SPAWN_POSITION = new Position[] {
        new Position((float)3, (float)-3, (float)-1),
        new Position((float)6, (float)-3, (float)-1),
        new Position((float)6, (float)-6, (float)-1),
        new Position((float)3, (float)-6, (float)-1)
    };


    readonly Position[] GREEN_SPAWN_POSITION = new Position[] {
        new Position((float)-3, (float)-3, (float)-1),
        new Position((float)-6, (float)-3, (float)-1),
        new Position((float)-6, (float)-6, (float)-1),
        new Position((float)-3, (float)-6, (float)-1)
    };

    readonly Position[] BLUE_SPAWN_POSITION = new Position[] {
        new Position((float)-3, (float)6,(float)-1),
        new Position((float)-6, (float)6, (float)-1),
        new Position((float)-6, (float)3, (float)-1),
        new Position((float)-3, (float)3, (float)-1)
    };

    const int RED_START_CASE = 0;
    const int YELLOW_START_CASE = 14;
    const int GREEN_START_CASE = 28;
    const int BLUE_START_CASE = 42;

    bool isGameRunning = false;
    int startingPlayer = 0;

    public Pawn clickedPawn { get; set; }

    private int currentRoll { get; set; }
    bool waitingForClick = false;

    [SerializeField] Case[] cases;
    [SerializeField] Player[] players;

    public void startTurn(Player player) {
        changeText(player + "'s turn");
        currentRoll = player.RollDice();
        Debug.Log(player + " rolled: " + currentRoll);
        if ((player.checkifAllPawnsAreInSpawn()) && (!player.checkifRollisSix(currentRoll))) { player.getPawns()[0].callNot6(); getStartingPlayer(); return; }
        setPawnsInteractable(player);
        waitingForClick = true;
        WaitUntil wait = new WaitUntil(() => clickedPawn != null);
    }

    private void changeText(string text) {
        text = text.Split(' ')[0];
        textMesh.text = text;
    }


    public void setPawnsInteractable(Player player, bool interactable = true) {
        Pawn[] pawns = player.getPawns();
        foreach(Pawn pawn in pawns) {
            pawn.isInteractable = interactable;
        }
    }


    public void getStartingPlayer() {
        if(startingPlayer < players.Length - 1) {
            startingPlayer++;
        } else {
            startingPlayer = 0;
        }
    }

    public void movePawnToStartCase(Pawn pawn) {
        pawn.moveToCase(cases[pawn.startPosition]);
        pawn.currentPosition = pawn.startPosition;
        pawn.isPawnInSpawn = false;
    }

    public void movePawn(Player player, int dice, Pawn pawn) {
        cases[pawn.currentPosition].clearCase();
        int newPosition = pawn.currentPosition + dice;
        if(newPosition > 55) {
            newPosition = newPosition - 56;
        }
        if(cases[newPosition].hasPawn) {
            cases[newPosition].pawn.moveToSpawn();
            cases[newPosition].pawn.isPawnInSpawn = true;
            pawn.moveToCase(cases[newPosition]);
            pawn.currentPosition = newPosition;
        } else {
            pawn.moveToCase(cases[newPosition]);
            pawn.currentPosition = newPosition;
        }
    }


    IEnumerator WaitForUserClick()
    {
        WaitUntil wait = new WaitUntil(() => clickedPawn != null);
        yield return wait;

        waitingForClick = false;

    }

    public void setClickedPawn(Pawn pawn) {
        clickedPawn = pawn;
    }

    private void handlePawnMove(Player player, int dice) {
        Debug.Log("Clicked pawn: " + clickedPawn);
            if(player.checkifAllPawnsAreInSpawn()) {
                if(player.checkifRollisSix(dice)) {
                    movePawnToStartCase(clickedPawn);
                } else {
                    clickedPawn.callNot6();
                }
            } else if ( clickedPawn.isPawnInSpawn ) {
                if(player.checkifRollisSix(dice)) {
                    movePawnToStartCase(clickedPawn);
                } else {
                    clickedPawn.callNot6();
                }
            } 
            else {
                movePawn(player, dice, clickedPawn);
            }
            if(currentRoll == 6) {
                return;
            } else {
                getStartingPlayer();
            }
            currentRoll = 0;
    }


    // Start is called before the first frame update
    void Start() 
    {


        clickedPawn = null;
        textMesh = FindObjectOfType<TMP_Text>();

        Debug.Log("Press space to start the game");
        isGameRunning = true;

        players[0].Color = "Red";
        
        for(int i = 0; i < players[0].getPawns().Length; i++) {
            players[0].getPawns()[i].spawnPosition = RED_SPAWN_POSITION[i];
            players[0].getPawns()[i].startPosition = RED_START_CASE;
        }


        players[1].Color = "Yellow";

        for(int i = 0; i < players[1].getPawns().Length; i++) {
            players[1].getPawns()[i].spawnPosition = YELLOW_SPAWN_POSITION[i];
            players[1].getPawns()[i].startPosition = YELLOW_START_CASE;
        }


        players[2].Color = "Green";

        for(int i = 0; i < players[2].getPawns().Length; i++) {
            players[2].getPawns()[i].spawnPosition = GREEN_SPAWN_POSITION[i];
            players[2].getPawns()[i].startPosition = GREEN_START_CASE;
        }


        players[3].Color = "Blue";

        for(int i = 0; i < players[3].getPawns().Length; i++) {
            players[3].getPawns()[i].spawnPosition = BLUE_SPAWN_POSITION[i];
            players[3].getPawns()[i].startPosition = BLUE_START_CASE;
        }
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

        if(waitingForClick) {
            StartCoroutine(WaitForUserClick());
        } 

        if(clickedPawn) {
            Debug.Log("Clicked pawn: " + clickedPawn);
            Debug.Log("Current roll: " + currentRoll);
            handlePawnMove(players[startingPlayer], currentRoll);
            clickedPawn = null;
        }
    }

}
