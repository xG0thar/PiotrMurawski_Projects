using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    void UpdateTargetArray();
    void SeekForTarget();
    GameObject ReturnTarget();
    void LockOnTarget(GameObject target);
    bool IsInRange(GameObject target);
    float CheckDistance(GameObject target);
}
