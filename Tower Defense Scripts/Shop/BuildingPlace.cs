using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    private bool isOccupied;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform.GetComponent<Transform>();
        isOccupied = false;
    }

    public Transform ReturnBuildingPosition()
    {
        return myTransform;
    }

    public bool isEmpty()
    {
        return !isOccupied;
    }

    public void SetOccupy(bool value)
    {
        isOccupied = value;
        //Gizmos.DrawSphere(this.transform.position, 3f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }

}
