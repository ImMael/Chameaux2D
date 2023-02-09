using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    [SerializeField] private Sprite[] faces;

    public int RollDice(){          
        int dice = Random.Range(1, 7);
        return dice;
    }

    public bool checkifRollisSix(int dice){
        return dice == 6 ? true : false;
    }

    public void updateRender(int dice){
        GetComponent<SpriteRenderer>().sprite = faces[dice - 1];
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
