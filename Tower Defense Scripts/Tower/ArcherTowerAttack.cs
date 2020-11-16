using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerAttack : TowerAttack
{
    private float attackRate = 0.5f;
    private float cooldown;
    public GameObject projectile;


    private void Update()
    {

        if(_target != null && cooldown <= 0)
        {
            Attack();
            cooldown += attackRate;
        }
        else if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public override void Attack()
    {
        var proj = Instantiate(projectile, this.transform);
        proj.GetComponent<MagicOrbProjectileMovement>().TargetAquired(_target.transform);
    }
}
