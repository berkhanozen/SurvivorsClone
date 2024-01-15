using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerWeaponController : MonoBehaviour
{
    [HideInInspector] public int isRight = 1;

    public List<Transform> weaponPointList;

    public List<GameObject> weapons;

    [SerializeField] Transform weaponContainer;

    private void Start()
    {
        SpawnWeapon(GetComponent<Player>().playerStats.startingWeapon);
    }

    private void OnEnable()
    {
        GetComponent<PlayerMovement>().MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        GetComponent<PlayerMovement>().MoveEvent -= OnMove;
    }

    private void SpawnWeapon(WeaponDataSO weaponData)
    {
        int weaponCount = 0;

        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab);

        for (int i = 0; i < weaponContainer.childCount; i++)
        {
            if (weaponGameObject.name == weaponContainer.GetChild(i).name)
            {
                weaponCount++;
            }
        }

        weaponGameObject.transform.position = weaponPointList[weaponCount].position;
        weaponGameObject.transform.SetParent(weaponContainer);
        weaponGameObject.GetComponentInChildren<Weapon>().SetData(weaponData);
        weapons.Add(weaponGameObject);

    }

    void OnMove(Vector2 moveDirection)
    {
        if (moveDirection.x > 0)
            isRight = 1;
        else if (moveDirection.x < 0)
            isRight = -1;
        else
            return;
    }
}

public enum Weapons
{
    Whip = 0,
    Knife = 1
}
