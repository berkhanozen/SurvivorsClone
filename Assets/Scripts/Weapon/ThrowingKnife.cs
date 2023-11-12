using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : Weapon
{
    [Header("Controller Settings")]
    [SerializeField] GameObject knife;

    private void Start()
    {
        StartCoroutine(WeaponLoopForSeconds());
    }

    IEnumerator WeaponLoopForSeconds()
    {
        while (true)
        {
            InstantiateKnife();
            yield return new WaitForSeconds(weaponStats.cooldown);
        }
    }
    
    void InstantiateKnife()
    {
        GameObject knifeGameObject = Instantiate(knife);
        knifeGameObject.transform.SetParent(transform);
        knifeGameObject.transform.position = transform.position;
        ControlDirection(knifeGameObject.transform, GetComponentInParent<PlayerWeaponController>());
        knifeGameObject.GetComponent<Knife>().weaponStats = weaponStats;
    }

}
