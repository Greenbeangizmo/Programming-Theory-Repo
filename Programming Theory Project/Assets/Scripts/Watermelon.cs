using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Crop //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        growthTime = 16;
        cropName = "Watermelon";

        stageOne = 12; //See Crop script for value reference
        stageTwo = 13;
        stageThree = 14;

        //currentDirtPlot is given from DirtPlot script on Instantiation

        StartCoroutine(Growth()); //POLYMORPHISM   
    }
}
