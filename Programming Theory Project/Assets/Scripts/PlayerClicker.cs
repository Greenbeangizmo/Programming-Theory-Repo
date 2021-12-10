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

    // Update is called once per frame
    void Update()
    {
        ClickDirt(); //ABSTRACTION
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
                dirtRenderer = dirtPlots[currentDirtPlot].GetComponent<Renderer>();
                dirtRenderer.material = wetDirt;
                dirtScript.isWet = true;
                break;
            case 1:
                //Potato Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet)
                {
                    dirtScript.PlantPotato(currentDirtPlot);
                }
                break;
            case 2:
                //Tomato Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet)
                {
                    dirtScript.PlantTomato(currentDirtPlot);
                }
                break;
            case 3:
                //Corn Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet)
                {
                    dirtScript.PlantCorn(currentDirtPlot);
                }
                break;
            case 4:
                //Carrot Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet)
                {
                    dirtScript.PlantCarrot(currentDirtPlot);
                }
                break;
            case 5:
                //Watermelon Seeds
                if (!dirtScript.isPlanted && dirtScript.isWet)
                {
                    dirtScript.PlantWatermelon(currentDirtPlot);
                }
                break;
        }
    }


}
