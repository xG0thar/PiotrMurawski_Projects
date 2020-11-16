using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TowerTarget))]
public abstract class TowerAttack : MonoBehaviour, IAttack
{
    public int attackPower = 2;
    public TowerTarget targetSystem;
    public GameObject _target;
    public event Action OnAttack;

    protected virtual void Awake()
    {
        targetSystem = GetComponent<TowerTarget>();
        targetSystem.OnTargetAquired += TargetSystem_OnTargetAquired;
        targetSystem.OnTargetLost += TargetSystem_OnTargetLost;
    }

    protected void TargetSystem_OnTargetLost()
    {
       _target = null;
    }

    protected void TargetSystem_OnTargetAquired()
    {
        _target = targetSystem.lockedTarget;
    }

    public virtual void Attack()
    {
        if(OnAttack != null)
            OnAttack();
        DealDamage(_target);
    }

    protected virtual void DealDamage(GameObject target)
    {
        target.GetComponent<IKillable>().Damage(attackPower);
    }
}
