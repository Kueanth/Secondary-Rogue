using UnityEngine;
using System.Collections.Generic;
using Leopotam.Ecs;

public class SceneData : MonoBehaviour
{
    public Transform mousePosition;
    public Vector2 playerSpawnPoint;
    public float playerSpeed;
    public Transform playerPosition;
    public Transform posEnemy;
    public Transform[] positionsEnemy;
    public EcsEntity playerEntity; 
}
