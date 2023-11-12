using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Whip : Weapon
{
    private void Start()
    {
        StartCoroutine(WeaponLoopForSeconds());
    }

    IEnumerator WeaponLoopForSeconds()
    {
        while (true)
        {
            ControlDirection(transform.parent, GetComponentInParent<PlayerWeaponController>());
            Animator whipAnim = gameObject.GetComponentInParent<Animator>();
            whipAnim.Rebind();
            whipAnim.Update(0f);
            yield return new WaitForSeconds(weaponStats.cooldown);
        }
    }
}
