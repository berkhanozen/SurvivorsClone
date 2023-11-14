using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public EnemyDataListSO enemyDataList;

    //public int spawnEnemy;
    private void Start()
    {
        SpawnEnemy(enemyDataList.enemies[0]);
        SpawnEnemy(enemyDataList.enemies[1]);
    }

    void SpawnEnemy(EnemyDataSO enemyData)
    {
        GameObject enemyGameObject = Instantiate(enemyData.enemyPrefab);
        enemyGameObject.GetComponentInChildren<Enemy>().SetEnemyData(enemyData);
    }
}
