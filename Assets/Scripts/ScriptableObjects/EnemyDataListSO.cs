using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyDataListSO")]
public class EnemyDataListSO : ScriptableObject
{
    public List<EnemyDataSO> enemies;
}
