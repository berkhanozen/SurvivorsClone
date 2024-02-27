using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponStats weaponStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Girildi");
        if (collision.gameObject.GetComponent<Enemy>())
        {
            OnEnemyHit(collision.gameObject.GetComponent<Enemy>());
        }
    }

    public void OnEnemyHit(Enemy enemy)
    {
        enemy.EnemyHitEvent?.Invoke(weaponStats.hitDamage);
    }

    public virtual void SetData(WeaponDataSO wd)
    {   
        weaponStats = new WeaponStats(wd.stats.hitDamage, wd.stats.cooldown, wd.stats.projectileSpeed);
    }

    public void ControlDirection(Transform targetTransform, PlayerWeaponController pwc) //ThrowingKnife, Whip
    {
        if(pwc.weaponCount < 1) // burada whipin, sayýsýna göre pozisyon almasýný deðiþtir.
        {
            if (pwc.isRight == 1)
            {
                targetTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                targetTransform.position = pwc.weaponPointList[0].transform.position;
            }
            else if (pwc.isRight == -1)
            {
                targetTransform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                targetTransform.position = pwc.weaponPointList[1].transform.position;
            }
        }
        else
        {
            pwc.weapons[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            targetTransform.position = pwc.weaponPointList[0].transform.position;
            pwc.weapons[1].transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            targetTransform.position = pwc.weaponPointList[1].transform.position;
        }    
    }
}