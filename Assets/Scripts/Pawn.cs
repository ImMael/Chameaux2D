using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Player player;

    public bool isPawnInSpawn { get; set; }  

    public bool isInteractable { get; set; }  

    public int currentPosition { get; set; }
    public int startPosition { get; set; }
    public Position spawnPosition { get; set; }

    public bool isClicked { get; set; }


    public void moveToCase(Case caseToMove) {
        caseToMove.hasPawn = true;
        caseToMove.pawn = this;
        transform.position = new Vector3(caseToMove.getPosition().x, caseToMove.getPosition().y, caseToMove.getPosition().z);
    }

    public void moveToSpawn() {
        transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }

    public void callNot6(){
        Debug.Log("Not 6!");
    }

    public int getPosition() {
        return currentPosition;
    }

    public void OnMouseDown() {
        if(isInteractable) {
            isClicked = true;
            Debug.Log("Pawn clicked: " + this);
            FindObjectOfType<GameScript>().setClickedPawn(this); 
            FindObjectOfType<GameScript>().setPawnsInteractable(player, false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isPawnInSpawn = true;
        isInteractable = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
