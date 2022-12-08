using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<Enemy> enemies;
    
    // это ВООБЩЕ НЕ РАБОТАЕТ ОН НЕ ВИДИТ enemy.sr ВООБЩЕ И Я НЕ ЗНАЮ ПОЧЕМУ
    public void CreateEnemy(Vector2 coordinates, Sprite sprite) 
    {
        GameObject enemyObject = new GameObject("Enemy");

        // Add the Enemy script to the GameObject
        Enemy enemy = enemyObject.AddComponent<Enemy>();
        enemy.Awake();
        
        enemy.transform.position = coordinates;
        enemy.sr.sprite = sprite;
        //enemy.boxCollider = gameObject.AddComponent<BoxCollider2D>();
        //enemy.Animator.runtimeAnimatorController = Animations;
        //enemy.boxCollider.size = new Vector2(0.1f,0.1f);

        // Add the Enemy GameObject as a child of the Enemy List GameObject.
        enemyObject.transform.SetParent(transform);

        // Add the Enemy GameObject to the enemies list.
        enemies.Add(enemy);
    }
}
