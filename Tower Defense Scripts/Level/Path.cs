using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private List<Transform> path;

    private void Awake()
    {
        path = new List<Transform>();

        for(int i = 0; i < transform.childCount; i++)
        {
            path.Add(transform.GetChild(i));
        }
    }
    
    public Transform GetNextPathPoint(int index, IMove caller)
    {
        if (index == transform.childCount)
        {
            caller.EndOfPath();
            return null;
        }
        else
        {
        return path[index];
        }
    }

    public Transform ReturnFirstPoint()
    {
        return path[0];
    }
}
