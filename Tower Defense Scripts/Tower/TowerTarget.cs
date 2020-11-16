using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerTarget : MonoBehaviour, ITarget
{
    public GameObject lockedTarget;
    public float lockinigRange;
    public GameObject[] targets;
    public string possibleTargetTag;
    public event Action OnTargetLost, OnTargetAquired;

    private void Update()
    {
        if(lockedTarget != null)
        {
            if (!IsInRange(lockedTarget))
            {
                lockedTarget = null;
                if (OnTargetLost != null)
                    OnTargetLost();
            }
        }
        else
        {
            UpdateTargetArray();
            SeekForTarget();
        }
    }

    public void LockOnTarget(GameObject target)
    {
        lockedTarget = target;
        if(OnTargetAquired != null)
            OnTargetAquired();
    }

    public GameObject ReturnTarget()
    {
        return lockedTarget;
    }

    public void UpdateTargetArray()
    {
        targets = GameObject.FindGameObjectsWithTag(possibleTargetTag);
    }

    public void SeekForTarget()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach(GameObject enemy in targets)
        {
            float distanceToEnemy = CheckDistance(enemy);
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        if(closestEnemy != null && distanceToClosestEnemy < lockinigRange)
        {
            LockOnTarget(closestEnemy);
        }

    }

    public bool IsInRange(GameObject target)
    {
        float distance = CheckDistance(target);
        if (distance <= lockinigRange)
            return true;
        return false;
    }

    public float CheckDistance(GameObject target)
    {
        float distance = Vector2.Distance(this.transform.position, target.transform.position);
        return distance; 
    }
}
