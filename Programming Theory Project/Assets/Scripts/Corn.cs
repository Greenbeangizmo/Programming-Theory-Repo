using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : Crop //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        growthTime = 15;
        cropName = "Corn";

        stageOne = 6; //See Crop script for value reference
        stageTwo = 7;
        stageThree = 8;

        //currentDirtPlot is given from DirtPlot script on Instantiation

        StartCoroutine(Growth()); //POLYMORPHISM   
    }
}
