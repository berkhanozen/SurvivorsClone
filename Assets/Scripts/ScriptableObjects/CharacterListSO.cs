using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterListSO")]
public class CharacterListSO : ScriptableObject
{
    public List<GameObject> characters;
}
