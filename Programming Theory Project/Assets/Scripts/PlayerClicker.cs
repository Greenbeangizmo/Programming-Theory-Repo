using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClicker : MonoBehaviour
{

    public GameObject[] dirtPlots;
    DirtPlot dirtScript;

    public Material dryDirt;
    public Material wetDirt;

    private Renderer dirtRenderer;

    private int currentItem;
    private int currentDirtPlot;

    private string currentCropName;

    private CropManager cropManagerScript;

    private void Start()
    {
        cropManagerScript = GameObject.Find("Crop Manager").GetComponent<CropManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickDirt(); //ABSTRACTION
        HarvestCrop(); //ABSTRACTION
    }

    private void ClickDirt()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < dirtPlots.Length; i++)
            {

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == dirtPlots[i].gameObject)
                    {
                        //Debug.Log("DirtPlot " + "\"" + i + "\" has been clicked");
                        currentDirtPlot = i;

                        CheckCurrentItem(); //ABSTRACTION
                        SelectItem(); //ABSTRACTION
                    }
                }
            }
        }
    }

    private void HarvestCrop()
    {
        if (Input.GetKeyDown("e"))
        {
            //Debug.Log("e has been pressed");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("e raycast hit");
                for (int i = 0; i < cropManagerScript.dirtPlots.Length; i++)
                {
                    //Debug.Log(hit.collider.gameObject.transform.parent.tag);
                    if (hit.collider.gameObject.transform.parent.tag == "Crop" + i && hit.collider.gameObject.transform.parent.name.Contains("3"))
                    {
                        Debug.Log("Crop" + i + " is named: " + hit.collider.gameObject.name);
                        GameObject[] cropsToHarvest = GameObject.FindGameObjectsWithTag("Crop" + i);

                        currentDirtPlot = i;
                        
                        foreach (GameObject crop in cropsToHarvest)
                        {
                            Destroy(crop);
                        }
                        currentCropName = hit.collider.gameObject.transform.parent.name;

                        FindCropTypeSeeds(); //ABSTRACTION
                    }
                }

            }
        }
    }

    private void FindCropTypeSeeds()
    {
        if (currentCropName.Contains("Potato"))
        {
            GameManager.PotatoSeeds += 2;
            cropManagerScript.inventoryValues[1].text = "x" + GameManager.PotatoSeeds;
            UnPlantDirt(); //ABSTRACTION
        }
        else if (currentCropName.Contains("Tomato"))
        {
            GameManager.TomatoSeeds += 2;
            cropManagerScript.inventoryValues[2].text = "x" + GameManager.TomatoSeeds;
            UnPlantDirt(); //ABSTRACTION
        }
        else if (currentCropName.Contains("Corn"))
        {
            GameManager.CornSeeds += 2;
            cropManagerScript.inventoryValues[3].text = "x" + GameManager.CornSeeds;
            UnPlantDirt(); //ABSTRACTION
        }
        else if (currentCropName.Contains("Carrot"))
        {
            GameManager.CarrotSeeds += 2;
            cropManagerScript.inventoryValues[4].text = "x" + GameManager.CarrotSeeds;
            UnPlantDirt(); //ABSTRACTION
        }
        else if (currentCropName.Contains("Watermelon"))
        {
            GameManager.WatermelonSeeds += 2;
            cropManagerScript.inventoryValues[5].text = "x" + GameManager.WatermelonSeeds;
            UnPlantDirt(); //ABSTRACTION
        }
    }

    private void UnPlantDirt()
    {
        dirtScript = dirtPlots[currentDirtPlot].GetComponent<DirtPlot>();
        dirtScript.isPlanted = false;
    }

    private void CheckCurrentItem()
    {
        currentItem = Hotbar.currentItem;
    }

    private void SelectItem()
    {
        //Gets the DirtPlot script from the clicked on dirt plot
        dirtScript = dirtPlots[currentDirtPlot].GetComponent<DirtPlot>();

        switch (currentItem)
        {
            case 0:
                //Watering Can
                if (GameManager.WaterLevel > 0 && dirtScript.isWet == false)
                {
                    dirtRenderer = dirtPlots[currentDirtPlot].GetComponent<Renderer>();
                    dirtRenderer.material = wetDirt;
                    dirtScript.isWet = true;
                    GameManager.WaterLevel -= 10;
                    cropManagerScript.inventoryValues[0].text = GameManager.WaterLevel + "%";
                }
                break;
            case 1:
                //Potato Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet && GameManager.PotatoSeeds > 0)
                {
                    dirtScript.PlantPotato(currentDirtPlot);
                }
                break;
            case 2:
                //Tomato Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet && GameManager.TomatoSeeds > 0)
                {
                    dirtScript.PlantTomato(currentDirtPlot);
                }
                break;
            case 3:
                //Corn Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet && GameManager.CornSeeds > 0)
                {
                    dirtScript.PlantCorn(currentDirtPlot);
                }
                break;
            case 4:
                //Carrot Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet && GameManager.CarrotSeeds > 0)
                {
                    dirtScript.PlantCarrot(currentDirtPlot);
                }
                break;
            case 5:
                //Watermelon Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet && GameManager.WatermelonSeeds > 0)
                {
                    dirtScript.PlantWatermelon(currentDirtPlot);
                }
                break;
        }
    }


}
