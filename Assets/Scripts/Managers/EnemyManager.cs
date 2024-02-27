using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public EnemyDataListSO enemyDataList;

    [SerializeField] float enemySpawnCooldown;

    Vector3 playerPos;

    private void Start()
    {
        GameManager.Instance.GameplayEvent += OnGameplayEvent;
    }

    private void OnGameplayEvent()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        if(GameManager.Instance.currentState == GameState.PLAYING)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        } 
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy(enemyDataList.enemies[0]);
            yield return new WaitForSeconds(enemySpawnCooldown);
        }

    }

    void SpawnEnemy(EnemyDataSO enemyData)
    {
        GameObject enemyGameObject = Instantiate(enemyData.enemyPrefab, RandomPosition(15,30,10,20), Quaternion.identity);
        enemyGameObject.GetComponentInChildren<Enemy>().SetEnemyData(enemyData);
    }

    Vector3 RandomPosition(int inclineX, int declineX, int inclineY, int declineY)
    {

        try
        {
            float posX;
            float posY;

            //düþmanlarýn kameranýn içerisinde spawn olmasýný istemiyoruz.

            posX = Random.Range(playerPos.x - declineX, playerPos.x + declineX); //Rastgele bir x deðeri al.

            if (posX < inclineX && posX > -inclineX) // Alýnan x deðeri kameranýn içerisindeyse y yi kameranýn dýþýnda olacak þekilde random atýyoruz.
            {
                int decidePosY = Random.Range(0, 2); // y sol taraftan mý kameranýn dýþýnda olsun sað taraftan mý

                if (decidePosY == 0)
                {
                    posY = Random.Range(playerPos.y - declineY, playerPos.y - inclineY);
                }
                else
                {
                    posY = Random.Range(playerPos.y + inclineY, playerPos.y + declineY);
                }
            }
            else
            {
                posY = Random.Range(-declineY, declineY);
            }

            return new Vector3(posX, posY, 0);
        }
        catch (System.Exception)
        {
            Debug.Log("Pozisyon verilemiyor");
            throw;
        }
        
    }

}
