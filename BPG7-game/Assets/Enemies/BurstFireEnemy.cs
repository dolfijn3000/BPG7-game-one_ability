using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireEnemy : Enemy
{
    [SerializeField] int shootsNumber;
    public override void Shoot()
    {
        StartCoroutine(BurstFire());
    }
    private IEnumerator BurstFire()
    {
        for (int i = 0; i < shootsNumber; i++)
        {
            base.Shoot();
            yield return new WaitForSeconds(.15f);
        }
    }
    }
