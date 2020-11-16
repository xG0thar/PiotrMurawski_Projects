using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileSeek
{
    void SetTarget(GameObject target);
    void SubscribeForTarget(ITargetAquired seeker);
    //event Action OnTargetAquired;
}
