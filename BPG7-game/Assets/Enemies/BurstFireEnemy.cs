using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireEnemy : Enemy
{
    [SerializeField] int shootsNumber;
    public Transform gunPointBurst ;
    public override void Shoot(Transform gunpoint)
    {
        StartCoroutine(BurstFire());
    }
    private IEnumerator BurstFire()
    {
        for (int i = 0; i < shootsNumber; i++)
        {
            base.Shoot(gunPointBurst);
            yield return new WaitForSeconds(.15f);
        }
    }
    }
