using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Button[] items;
    public static int currentItem { private set; get; } //ENCAPSULATION

    private int previousItem = 0;

    KeyCode[] keycodes = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };


    // Start is called before the first frame update
    void Start()
    {
        currentItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSelectedItem(); //ABSTRACTION
    }

    private void ChangeSelectedItem()
    {

        for (int i = 0; i < keycodes.Length; i++)
        {
            if (Input.GetKeyDown(keycodes[i]))
            {
                //Debug.Log("Pressed " + keycodes[i] + " Key");
                items[previousItem].interactable = true;

                currentItem = i;
                items[i].Select();

                previousItem = i;
                items[i].interactable = false;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //Debug.Log("ScrollWheel Positive");

            if (currentItem < (items.Length - 1))
            {
                items[previousItem].interactable = true;

                currentItem++;
                items[currentItem].Select();

                previousItem = currentItem;
                items[currentItem].interactable = false;
            }
            else
            {
                items[previousItem].interactable = true;

                currentItem = 0;
                items[currentItem].Select();

                previousItem = currentItem;
                items[currentItem].interactable = false;
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //Debug.Log("ScrollWheel Negative");

            if (currentItem > 0)
            {
                items[previousItem].interactable = true;

                currentItem--;
                items[currentItem].Select();

                previousItem = currentItem;
                items[currentItem].interactable = false;
            }
            else
            {
                items[previousItem].interactable = true;

                currentItem = items.Length - 1;
                items[currentItem].Select();

                previousItem = currentItem;
                items[currentItem].interactable = false;
            }
        }
    }
}
