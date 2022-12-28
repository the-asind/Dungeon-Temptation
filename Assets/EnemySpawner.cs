using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DungeonCreature
{
    public class EnemySpawner : MonoBehaviour
    {
        //private System.Random _r;
        [SerializeField] private Sprite renderer;
        [SerializeField] private EnemyList _enemyList;
        
        //public RuntimeAnimatorController[] Animations;

        public void SpawnEnemy(Vector2 coordinates)
        {
            //int index = r.Next(0, Sprite.Length);
            _enemyList.CreateEnemy(coordinates, renderer);
        }

        public EnemySpawner()
        {
            //Awake();
            //_r = new System.Random();
            //Animations = new RuntimeAnimatorController[1];
        }
    }
}