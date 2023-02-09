using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Player player;

    public bool isPawnInSpawn { get; set; }    


    public void moveToCase(Case caseToMove) {
        caseToMove.hasPawn = true;
        caseToMove.pawn = this;
        transform.position = new Vector3(caseToMove.getPosition().x, caseToMove.getPosition().y, caseToMove.getPosition().z);
    }

    public void moveToSpawn() {
        transform.position = new Vector3(player.spawnPosition.x, player.spawnPosition.y, player.spawnPosition.z);
    }

    public void callNot6(){
        Debug.Log("Not 6!");
    }

    // Start is called before the first frame update
    void Start()
    {
        isPawnInSpawn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
