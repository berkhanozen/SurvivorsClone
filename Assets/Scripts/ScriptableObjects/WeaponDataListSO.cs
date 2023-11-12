using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponDataListSO")]
public class WeaponDataListSO : ScriptableObject
{
    public List<WeaponDataSO> weapons;
}
