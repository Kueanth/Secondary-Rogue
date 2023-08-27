using UnityEngine;
using Leopotam.Ecs;
using System.Linq;

public class EnemyInit : IEcsInitSystem
{
    private EcsWorld _world;

    private SceneData sceneData;
    private StaticData configuration;

    public void Init()
    {
        sceneData.positionsEnemy = sceneData.posEnemy.transform.GetComponentsInChildren<Transform>();

        foreach(var i in sceneData.positionsEnemy)
        {
            if (i.name == "SpawnEnemy") continue;
            if (i.name == "Check") continue;

            GameObject enemyObject = GameObject.Instantiate(configuration.Enemy, i.position, Quaternion.identity);

            EcsEntity enemy = _world.NewEntity();

            ref EnemyData components = ref enemy.Get<EnemyData>();

            enemy.Get<EnemyNewFollow>();

            components.number = 0;
            components.transform = enemyObject.transform;
            components.rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();

            enemyObject.GetComponent<EnemyTrigger>().entity = enemy;

            components.targets = i.transform.GetComponentsInChildren<Transform>();
            foreach(var meow in components.targets)
            {
                Debug.Log(meow);
            }
        }
    }   
}
