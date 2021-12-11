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

    public void PlantPotato(int currentDirtPlot)
    {
        Debug.Log("Potato seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        spawnCrop = Instantiate(crops[0], gameObject.transform.position, gameObject.transform.rotation);
        spawnCrop.tag = "Crop" + currentDirtPlot;
        crops[0].GetComponent<Potato>().currentDirtPlot = currentDirtPlot;
        
    }
    public void PlantTomato(int currentDirtPlot)
    {
        Debug.Log("Tomato seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        Instantiate(crops[1], gameObject.transform.position, gameObject.transform.rotation);
    }
    public void PlantCorn(int currentDirtPlot)
    {
        Debug.Log("Corn seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        Instantiate(crops[2], gameObject.transform.position, gameObject.transform.rotation);
    }
    public void PlantCarrot(int currentDirtPlot)
    {
        Debug.Log("Carrot seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        Instantiate(crops[3], gameObject.transform.position, gameObject.transform.rotation);
    }
    public void PlantWatermelon(int currentDirtPlot)
    {
        Debug.Log("Watermelon seed planted at dirt plot: " + currentDirtPlot);
        isPlanted = true;
        Instantiate(crops[4], gameObject.transform.position, gameObject.transform.rotation);
    }


}
