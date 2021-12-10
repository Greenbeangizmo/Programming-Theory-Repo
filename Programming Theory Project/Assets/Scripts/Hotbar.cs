using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Button[] items;
    public static int currentItem { private set; get; } //ENCAPSULATION

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
                Debug.Log("Pressed " + keycodes[i] + " Key");
                currentItem = i;
                items[i].Select();
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("ScrollWheel Positive");

            if (currentItem < (items.Length - 1))
            {
                currentItem++;
                items[currentItem].Select();
            }
            else
            {
                currentItem = 0;
                items[currentItem].Select();
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("ScrollWheel Negative");

            if (currentItem > 0)
            {
                currentItem--;
                items[currentItem].Select();
            }
            else
            {
                currentItem = items.Length - 1;
                items[currentItem].Select();
            }
        }
    }
}
