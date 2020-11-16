using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokkenView : MonoBehaviour
{
    [SerializeField]
    public TokkenScriptable tokken;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.sprite = tokken.tokkenSprite;
    }
}
