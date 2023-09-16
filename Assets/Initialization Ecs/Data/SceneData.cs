using UnityEngine;
using System.Collections.Generic;
using Leopotam.Ecs;

public class SceneData : MonoBehaviour
{
    public EcsEntity playerEntity;

    public Vector2 playerSpawnPoint;

    public float playerSpeed;

    public int enemyCount;

    public bool levelComplete;

    public Transform playerPosition;
    public Transform mousePosition;

    public Transform posChest;
    public Transform posEnemy;
    public Transform posHatch;

    public Animator vignetteEffect;

    public Transform[] positionsEnemy;
    public Transform[] positionsChests;
    public Transform[] positionsHatchs;
    public GameObject[] hatchs;
}
