using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameResources")]
public class GameResources : ScriptableObject
{
    public CharacterListSO characterList;

    public WeaponDataListSO weaponDataList;
}
