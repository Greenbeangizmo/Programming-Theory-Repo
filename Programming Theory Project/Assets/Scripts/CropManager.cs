using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CropManager : MonoBehaviour
{
    public GameObject[] dirtPlots;

    public GameObject[] cropStages;

    public TextMeshProUGUI[] inventoryValues;


    private void Start()
    {
        inventoryValues[0].text = GameManager.WaterLevel + "%";
        inventoryValues[1].text = "x" + GameManager.PotatoSeeds;
        inventoryValues[2].text = "x" + GameManager.TomatoSeeds;
        inventoryValues[3].text = "x" + GameManager.CornSeeds;
        inventoryValues[4].text = "x" + GameManager.CarrotSeeds;
        inventoryValues[5].text = "x" + GameManager.WatermelonSeeds;
    }
}
