using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToWall : MonoBehaviour
{

    // Checkpoint Position
    [SerializeField]
    private Transform checkPoint;

    //Reference to UI text for DISTANCE
    [SerializeField]
    private Text distanceText;

    

    //Calculate Distance
    private float distance;

    

    // Update is called once per frame
    void Update()
    {
        //Calculate the distance based on X axis
        distance = (checkPoint.transform.position.z - transform.position.z);

        //Display Distance via UI
        distanceText.text = "Distance: " + distance.ToString("F1") + " meters";

        //Display Score text
        

        //Perfect shot
        if(distance <=0)
        {
            distanceText.text = "PERFECT SHOT!!";
        }
    }
}
