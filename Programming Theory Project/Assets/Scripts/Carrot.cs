using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Crop //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        growthTime = 6;
        cropName = "Carrot";

        stageOne = 9; //See Crop script for value reference
        stageTwo = 10;
        stageThree = 11;

        //currentDirtPlot is given from DirtPlot script on Instantiation

        StartCoroutine(Growth()); //POLYMORPHISM   
    }
}
