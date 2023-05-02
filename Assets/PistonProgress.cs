using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonProgress : MonoBehaviour
{
    //Variables used to calculate total distance to make percentage of the course the piston has traversed
    private GameObject finishLine = null;
    private GameObject wall = null;
    private GameObject start = null;
    private float startX;
    private float finishX;
    private float totalDistance;

    //Variables used in changing the progress bar
    private float newWidth;
    private float barXOffset;

    private RectTransform rectangle; //This is the actual progress bar that gets changed
    private float progressBarWidth = 300f; //Manually set

    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<RectTransform>();
        wall = GameObject.Find("Wall");
        finishLine = GameObject.Find("Finish");
        start = GameObject.Find("Start");
        startX = start.transform.position.x;
        finishX = finishLine.transform.position.x;
        totalDistance = finishX - startX;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates the width of progress bar by percentage of the course traversed and multiplying it by total bar width
        newWidth = ((wall.transform.position.x - startX)/totalDistance) * progressBarWidth; 
        barXOffset = newWidth - rectangle.sizeDelta.x; //Since the bar grows on both sides, the bar needs to be offset in order for the left side to stay flush
        rectangle.sizeDelta = new Vector2(newWidth, rectangle.sizeDelta.y);
        rectangle.transform.position = new Vector3(rectangle.transform.position.x + (barXOffset / 2), rectangle.transform.position.y, 0);
    }
}
