using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireEnemy : Enemy
{
    [SerializeField] int shootsNumber;
    Transform GunPoint ;
    public override void Shoot(Transform gunpoint)
    {
        StartCoroutine(BurstFire());
    }
    private IEnumerator BurstFire()
    {
        for (int i = 0; i < shootsNumber; i++)
        {
            base.Shoot(GunPoint);
            yield return new WaitForSeconds(.15f);
        }
    }
    }
