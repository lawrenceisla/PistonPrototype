using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonMovement : MonoBehaviour
{
    private GameObject finishLine = null;
    private GameObject wall = null;
    private GameObject rod = null;
    private float finishX;
    
    public float pistonSpeed = 10f; //Change this variable to speed or slow piston
    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("Wall");
        rod = GameObject.Find("Rod");
        finishLine = GameObject.FindGameObjectWithTag("Finish");
        finishX = finishLine.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (wall.transform.position.x < finishX){
            wall.transform.position = new Vector3(wall.transform.position.x + (pistonSpeed / 500), wall.transform.position.y, 0);
            rod.transform.position = new Vector3(rod.transform.position.x + (pistonSpeed / 500), rod.transform.position.y, 0);
        }
    }
}
