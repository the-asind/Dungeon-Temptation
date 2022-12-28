using System;
using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField]
    public List<EnemyBehaviour> enemies;

    public void CreateEnemy(Vector2 coordinates, Sprite sprite) 
    {
        GameObject enemyObject = new GameObject("Enemy");

        // Add the Enemy script to the GameObject
        EnemyBehaviour enemy = enemyObject.AddComponent<EnemyBehaviour>();

        enemy.transform.position = coordinates;
        enemy.ChangeSprite(sprite);
        //enemy.ChangeAnimation(Animations[index]);

        // Add the Enemy GameObject as a child of the Enemy List GameObject.
        enemyObject.transform.SetParent(transform);

        // Add the Enemy GameObject to the enemies list.
        enemies.Add(enemy);
    }
}
