using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tokken))]
public class TokkenMove : MonoBehaviour
{
    private Tokken tokken;

    private Camera camera;

    private bool isDrag;

    private bool overEmptyHex;
    private Transform targetEmptyHex;
    private Hex targetEmptyHexModule;
    private void Awake()
    {
        tokken = GetComponent<Tokken>();
        camera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (!tokken.isPlaced && !isDrag)
        {
            isDrag = true;
        }else if(isDrag && overEmptyHex)
        {
            isDrag = false;
            transform.position = targetEmptyHex.position;
            targetEmptyHexModule.InsertTokken(tokken);
            tokken.posOnBoardX = targetEmptyHexModule.ReturnPositionX();
            tokken.posOnBoardY = targetEmptyHexModule.ReturnPositionY();
            tokken.isPlaced = true;
        }else if (isDrag)
        {
            isDrag = false;
        }

    }


    void Update()
    {
        if (isDrag)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            transform.position = new Vector3(ray.origin.x, ray.origin.y, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BoardHex"))
        {
            targetEmptyHexModule = collision.collider.GetComponentInParent<Hex>();
            //targetEmptyHex = collision.collider.GetComponent<Transform>();
            if (!targetEmptyHexModule.isOccupied)
            {
                overEmptyHex = true;
                targetEmptyHex = collision.collider.GetComponent<Transform>();
            }
            else
            {
                overEmptyHex = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        overEmptyHex = false;
        targetEmptyHex = null;
        targetEmptyHexModule = null;
    }
}
