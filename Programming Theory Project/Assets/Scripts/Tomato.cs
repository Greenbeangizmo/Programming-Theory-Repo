using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Crop //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        growthTime = 8;
        cropName = "Tomato";

        stageOne = 3; //See Crop script for value reference
        stageTwo = 4;
        stageThree = 5;

        //currentDirtPlot is given from DirtPlot script on Instantiation

        StartCoroutine(Growth()); //POLYMORPHISM
    }
}
