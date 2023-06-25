using UnityEngine;
using Leopotam.Ecs;

public class EnemyInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    public void Init()
    {
        sceneData.positionsEnemy = configuration.spawnPointEnemy.GetComponentsInChildren<Transform>();

        foreach(var i in sceneData.positionsEnemy)
        {
            GameObject enemy = GameObject.Instantiate(configuration.Enemy, i.position, Quaternion.identity);
        }
    }   
    
}
