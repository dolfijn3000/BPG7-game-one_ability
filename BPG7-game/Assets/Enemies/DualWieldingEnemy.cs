using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWieldingEnemy : Enemy
{
    public Transform[] gunPoints;
    public override void Shoot(Transform gunpoint)
    {
        foreach (var gun in gunPoints)
        {
            Instantiate(bulletPrefab,gun.position, transform.rotation);
        }
    }
}
