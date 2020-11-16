using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    //Ma tylko ładować i udostępniać listę przycisków ze sklepu             ##################################################
    private List<Button> buttons;
    private int buttonCount;

    private void Awake()
    {
        buttons = new List<Button>();
        LoadButtons();
    }

    private void LoadButtons()
    {
        buttons = new List<Button>();
        buttonCount = transform.childCount;
        for (int i = 0; i < buttonCount; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
        }
    }

    public Button ReturnButtonFromList(int index)
    {
        return buttons[index];
    }

    public int ReturnButtonCount()
    {
        return buttonCount;
    }
}
