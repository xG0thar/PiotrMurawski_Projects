using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokkenTest : MonoBehaviour
{
    [SerializeField]
    private Tokken tokken;

    [SerializeField]
    private Transform targetOnBoard;

    private void Awake()
    {
        tokken = GetComponent<Tokken>();
    }
    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(ray.origin.x, ray.origin.y, 1);
    }

    private void OnMouseUp()
    {
        if(targetOnBoard != null)
        {
            transform.position = targetOnBoard.position;
            targetOnBoard.GetComponentInParent<Hex>().InsertTokken(tokken);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision! With {collision.gameObject.name}");
        if (collision.collider.CompareTag("BoardHex"))
        {
            targetOnBoard = collision.collider.GetComponent<Transform>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        targetOnBoard = null;
    }

}