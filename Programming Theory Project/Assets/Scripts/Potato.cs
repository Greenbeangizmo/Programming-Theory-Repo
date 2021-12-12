using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Crop //INHERITANCE
{    
    private void Start()
    {
        growthTime = 10;
        cropName = "Potato";

        stageOne = 0; //See Crop script for value reference
        stageTwo = 1;
        stageThree = 2;

        //currentDirtPlot is given from DirtPlot script on Instantiation

        StartCoroutine(Growth()); //POLYMORPHISM
    }

}
