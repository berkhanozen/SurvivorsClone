using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    float knifeSpeed;
    
    private void Start()
    {
        knifeSpeed = weaponStats.projectileSpeed * GetComponentInParent<PlayerWeaponController>().isRight;
        
        transform.SetParent(GameManager.Instance.projectilePool);
    }

    private void Update()
    {
        transform.position += new Vector3(knifeSpeed, 0, 0) * Time.deltaTime;
    }
}
