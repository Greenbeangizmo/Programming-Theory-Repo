using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crop : MonoBehaviour
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

    protected GameObject stageOneCrop;
    protected GameObject stageTwoCrop;
    protected GameObject stageThreeCrop;


    public virtual IEnumerator Growth()
    {
        cropManagerScript = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        stageOneCrop = gameObject;
        
        stageTwoCrop = cropManagerScript.cropStages[stageTwo];
        stageThreeCrop = cropManagerScript.cropStages[stageThree];
        Debug.Log("Stage 1");

        yield return new WaitForSeconds(growthTime);

        for (int i = 0; i < stageOneCrop.transform.childCount; i++)
        {
            stageOneCrop.transform.GetChild(i).gameObject.SetActive(false);
        }

        Debug.Log("Stage 2");
        Instantiate(stageTwoCrop, gameObject.transform.position, gameObject.transform.rotation);
        
        yield return new WaitForSeconds(growthTime);

        for (int i = 0; i < stageTwoCrop.transform.childCount; i++)
        {
            stageTwoCrop.transform.GetChild(i).gameObject.SetActive(false);
        }

        Debug.Log("Stage 3");
        Instantiate(stageThreeCrop, gameObject.transform.position, gameObject.transform.rotation);
        

        //yield return null;

    }

}
