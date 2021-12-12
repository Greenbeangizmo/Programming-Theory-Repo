using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPlot : MonoBehaviour
{
    public Material dryDirt;
    public Material wetDirt;

    public GameObject[] crops;

    public bool isWet;
    public bool isPlanted;

    private GameObject spawnCrop;

    private CropManager cropManagerScript;

    private void Start()
    {
        cropManagerScript = GameObject.Find("Crop Manager").GetComponent<CropManager>();
    }

    public void PlantPotato(int currentDirtPlot)
    {
        Debug.Log("Potato seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        GameManager.PotatoSeeds--;
        cropManagerScript.inventoryValues[1].text = "x" + GameManager.PotatoSeeds;
        spawnCrop = Instantiate(cropManagerScript.cropStages[0], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        spawnCrop.GetComponent<Potato>().currentDirtPlot = currentDirtPlot;
        
    }
    public void PlantTomato(int currentDirtPlot)
    {
        Debug.Log("Tomato seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        GameManager.TomatoSeeds--;
        cropManagerScript.inventoryValues[2].text = "x" + GameManager.TomatoSeeds;
        spawnCrop = Instantiate(cropManagerScript.cropStages[3], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        spawnCrop.GetComponent<Tomato>().currentDirtPlot = currentDirtPlot;
    }
    public void PlantCorn(int currentDirtPlot)
    {
        Debug.Log("Corn seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        GameManager.CornSeeds--;
        cropManagerScript.inventoryValues[3].text = "x" + GameManager.CornSeeds;
        spawnCrop = Instantiate(cropManagerScript.cropStages[6], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        spawnCrop.GetComponent<Corn>().currentDirtPlot = currentDirtPlot;
    }
    public void PlantCarrot(int currentDirtPlot)
    {
        Debug.Log("Carrot seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        GameManager.CarrotSeeds--;
        cropManagerScript.inventoryValues[4].text = "x" + GameManager.CarrotSeeds;
        spawnCrop = Instantiate(cropManagerScript.cropStages[9], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        spawnCrop.GetComponent<Carrot>().currentDirtPlot = currentDirtPlot;
    }
    public void PlantWatermelon(int currentDirtPlot)
    {
        Debug.Log("Watermelon seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        GameManager.WatermelonSeeds--;
        cropManagerScript.inventoryValues[5].text = "x" + GameManager.WatermelonSeeds;
        spawnCrop = Instantiate(cropManagerScript.cropStages[12], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        spawnCrop.GetComponent<Watermelon>().currentDirtPlot = currentDirtPlot;
    }


}
