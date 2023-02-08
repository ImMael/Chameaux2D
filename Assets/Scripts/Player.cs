using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Pawn[] pawns;

    public string Color { get; set; }
    public int startPosition { get; set; }
    public int currentPosition { get; set; }
    public Position spawnPosition { get; set; }

    public int RollDice(){          
        int dice = Random.Range(1, 7);
        return dice;
    }

    public Pawn[] getPawns(){
        return pawns;
    }

    public bool checkifRollisSix(int dice){
        return dice == 6 ? true : false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
