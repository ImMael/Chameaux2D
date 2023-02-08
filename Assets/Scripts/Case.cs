using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position {
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }

    public Position(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class Case : MonoBehaviour {

    public bool hasPawn { get; set; }
    public Pawn pawn { get; set; }

    public Position getPosition() {
        return new Position((float)transform.position.x, (float)transform.position.y, (float)transform.position.z);
    }

    public void clearCase(){
        hasPawn = false;
        pawn = null;
    }



    void Start() {

        hasPawn = false;
        pawn = null;


    }

    void Update() {


        
    }
}