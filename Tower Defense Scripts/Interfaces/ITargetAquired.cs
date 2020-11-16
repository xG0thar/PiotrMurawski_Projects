using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetAquired
{
    void TargetAquired(Transform target);
    bool HasTarget();
}
