using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonsDisplay : MonoBehaviour
{
    //Ustawia i odświeża ikony oraz ceny w sklepie@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    private List<TowerStructure> _towers;
    private ShopButtons _shopButtons;
    private ShopTexts _shopTexts;
    private int defaultStage = 0;

    private void Awake()
    {
        _shopButtons = GetComponentInChildren<ShopButtons>();
        _shopTexts = GetComponentInChildren<ShopTexts>();
    }

    private void Start()
    {
        _towers = FindObjectOfType<LevelResourceManager>().GetAvailableTowers().towers;
        DisplayDefaultStage();
    }

    private void DisplayDefaultStage()
    {
        int buttonCount = _shopButtons.ReturnButtonCount();
        int textCount = _shopTexts.ReturnTextCount();
        if(buttonCount != textCount)
        {
            Debug.LogError("Number of buttons is not equal to number of text in: " + this.gameObject);
            return;
        }
        for (int i = 0; i < buttonCount; i++)
        {
            if(_towers[i] != null)
            {
                var button = _shopButtons.ReturnButtonFromList(i);
                var text = _shopTexts.ReturnTextFromList(i);
                InsertIconSprite(button.image, _towers[i].towerBlueprints[defaultStage].towerIcon);
                InsertPrice(text, _towers[i].towerBlueprints[defaultStage].towerCost);
            }
        }
    }

    private void RefreshDisplayForStage(int stageIndex)
    {
        //Tu przyjdzie inicjalizacja ikon dla kolejnych stage'ów budowy
    }

    private void InsertIconSprite(Image icon, Sprite sprite)
    {
        icon.sprite = sprite;
    }
    private void InsertPrice(Text text, int price)
    {
        text.text = price.ToString();
    }
}
