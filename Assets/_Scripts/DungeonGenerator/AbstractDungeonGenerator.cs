using System;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualizer tilemapVisualizer;
    [SerializeField] protected Player player;
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

    

    public void GenerateDungeon()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}