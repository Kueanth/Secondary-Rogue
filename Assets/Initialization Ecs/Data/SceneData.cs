using UnityEngine;
using System.Collections.Generic;
using Leopotam.Ecs;

public class SceneData : MonoBehaviour
{
    public EcsEntity playerEntity;
    public EcsEntity roomEntity;
    public EcsEntity gunEntity;

    public Vector2 playerSpawnPoint;

    public float playerSpeed;

    public int enemyCount;

    public int countKillEnemy;

    public bool levelComplete;

    public int countLevel;

    public PlayerParticle playerParticle;

    public GameObject particleSystemForPlayer;

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

    public bool paused = false;
}
