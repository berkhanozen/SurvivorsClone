using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimonk : Enemy
{
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyStats.moveSpeed * Time.deltaTime);

        Debug.Log(name + enemyStats.health);
    }
}
