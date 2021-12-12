using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Crop : MonoBehaviour //INHERITANCE
{
    protected int growthTime;

    public int currentDirtPlot;

    protected string cropName; //Potato, Tomato, Corn, Carrot, Watermelon

    //protected int growthStage = 0; //Seedling, Vegetative, Fruiting

    protected int stageOne = 0;
    protected int stageTwo = 1;
    protected int stageThree = 2;
    // 0-2 = Potato, 3-5 = Tomato, 6-8 = Corn, 9-11 = Carrot, 12-14 = Watermelon

    protected CropManager cropManagerScript;

    protected GameObject stageOneCrop; //Reference to Prefab
    protected GameObject stageTwoCrop; //Reference to Prefab
    protected GameObject stageThreeCrop; //Reference to Prefab

    protected GameObject spawnCropTwo; //Reference to Created GameObject
    protected GameObject spawnCropThree; //Reference to Created GameObject


    public virtual IEnumerator Growth()
    {
        cropManagerScript = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        stageOneCrop = gameObject;
        
        stageTwoCrop = cropManagerScript.cropStages[stageTwo];
        stageThreeCrop = cropManagerScript.cropStages[stageThree];
        //Debug.Log("Stage 1");

        yield return new WaitForSeconds(growthTime);

        for (int i = 0; i < stageOneCrop.transform.childCount; i++)
        {
            stageOneCrop.transform.GetChild(i).gameObject.SetActive(false);
        }

        //Debug.Log("Stage 2");
        spawnCropTwo = Instantiate(stageTwoCrop, gameObject.transform.position, gameObject.transform.rotation);
        spawnCropTwo.tag = "Crop" + currentDirtPlot;
        Debug.Log("Stage 2 currentDirtPlot = " + currentDirtPlot);

        yield return new WaitForSeconds(growthTime);

        spawnCropTwo.gameObject.SetActive(false);

        //Debug.Log("Stage 3");
        spawnCropThree = Instantiate(stageThreeCrop, gameObject.transform.position, gameObject.transform.rotation);
        spawnCropThree.tag = "Crop" + currentDirtPlot;
        Debug.Log("Stage 3 currentDirtPlot = " + currentDirtPlot);


        //yield return new WaitForSeconds(growthTime);
        //Destroy(spawnCropThree);
        //Destroy(spawnCropTwo);
        //Destroy(stageOneCrop);

        yield return null;

    }

}
