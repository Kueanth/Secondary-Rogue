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

            enemyObject.transform.SetParent(i);

            EcsEntity enemy = _world.NewEntity();

            ref EnemyData components = ref enemy.Get<EnemyData>();

            enemy.Get<EnemyNewFollow>();

            components.number = 0;
            components.hp = 5;
            components.transform = enemyObject.transform;
            components.rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();
            components.animator = enemyObject.GetComponent<Animator>();
            components.transform.GetComponent<EnemyShoot>().target = sceneData.playerPosition;
            components.timerForShoot = Random.Range(3, 6);

            enemyObject.GetComponent<EnemyShoot>().entity = enemy;
            enemyObject.GetComponent<EnemyShoot>().entityPlayer = sceneData.playerEntity;
            enemyObject.GetComponent<EnemyTrigger>().entity = enemy;

            components.targets = i.transform.GetComponentsInChildren<Transform>();
        }
    }   
}
