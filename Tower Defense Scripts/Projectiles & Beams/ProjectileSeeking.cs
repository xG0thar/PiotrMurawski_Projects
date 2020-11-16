using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSeeking : IProjectileSeek
{
    private GameObject _target;
    //public event Action OnTargetAquired;
    public ITargetAquired subscriber;

    public void SetTarget(GameObject target)
    {
        _target = target;
        TargetAquired();
    }

    public void TargetAquired()
    {
        subscriber.TargetAquired(_target.transform);
    }

    public void SubscribeForTarget(ITargetAquired seeker)
    {
        subscriber = seeker;
    }
}
