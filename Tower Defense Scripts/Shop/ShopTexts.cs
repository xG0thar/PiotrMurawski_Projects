using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTexts : MonoBehaviour
{
    //Ma tylko ładować i udostępniać listę textów ze sklepu             ##################################################

    private List<Text> texts;
    private int textCount;

    private void Awake()
    {
        texts = new List<Text>();
        LoadTexts();
    }

    private void LoadTexts()
    {
        texts = new List<Text>();
        textCount = transform.childCount;
        for (int i = 0; i < textCount; i++)
        {
            texts.Add(transform.GetChild(i).GetComponent<Text>());
        }
    }

    public Text ReturnTextFromList(int index)
    {
        return texts[index];
    }

    public int ReturnTextCount()
    {
        return textCount;
    }
}
