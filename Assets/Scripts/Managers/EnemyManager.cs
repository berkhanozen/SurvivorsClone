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
        SpawnEnemy(enemyDataList.enemies[0]);
        SpawnEnemy(enemyDataList.enemies[0]);
        SpawnEnemy(enemyDataList.enemies[0]);
        SpawnEnemy(enemyDataList.enemies[0]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
        //SpawnEnemy(enemyDataList.enemies[1]);
    }

    void SpawnEnemy(EnemyDataSO enemyData)
    {
        GameObject enemyGameObject = Instantiate(enemyData.enemyPrefab, RandomPosition(), Quaternion.identity);
        enemyGameObject.GetComponentInChildren<Enemy>().SetEnemyData(enemyData);
    }

    Vector3 RandomPosition()
    {
        int posX = Random.Range(-10, 10);
        int posY = Random.Range(-10, 10);
        return new Vector3(posX, posY, 0);
    }
}
