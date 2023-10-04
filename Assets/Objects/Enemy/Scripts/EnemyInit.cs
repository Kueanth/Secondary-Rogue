using UnityEngine;
using Leopotam.Ecs;
using System.Linq;

public class EnemyInit : IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld _world;

    private EcsFilter<RoomDestroy, RoomCreate> _filter;

    private SceneData sceneData;
    private StaticData configuration;
    private UI ui;
    private EnemyObject[] enemyObjects;

    public void Init()
    {
        sceneData.positionsEnemy = sceneData.posEnemy.transform.GetComponentsInChildren<Transform>();
        sceneData.enemyCount = 0;

        foreach(var i in sceneData.positionsEnemy)
        {
            if (i.name == "SpawnEnemy") continue;
            if (i.name == "Check") continue;

            int temp = Random.Range(0, enemyObjects.Length);

            GameObject enemyObject = GameObject.Instantiate(enemyObjects[temp].enemyObject, i.position, Quaternion.identity);

            enemyObject.transform.SetParent(i);

            EcsEntity enemy = _world.NewEntity();

            ref EnemyData components = ref enemy.Get<EnemyData>();

            enemy.Get<EnemyNewFollow>();

            components.number = 0;
            components.hp = enemyObjects[temp].hp;
            components.name = enemyObjects[temp].name;
            components.transform = enemyObject.transform;
            components.rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();
            components.animator = enemyObject.GetComponent<Animator>();
            components.transform.GetComponent<EnemyShoot>().target = sceneData.playerPosition;
            components.timerForShoot = Random.Range(3, 6);

            enemyObject.GetComponent<EnemyShoot>().entity = enemy;
            enemyObject.GetComponent<EnemyShoot>().entityPlayer = sceneData.playerEntity;
            enemyObject.GetComponent<EnemyTrigger>().entity = enemy;
            enemyObject.GetComponent<EnemyTrigger>().sceneData = sceneData;
            enemyObject.GetComponent<EnemyTrigger>().ui = ui;

            components.targets = i.transform.GetComponentsInChildren<Transform>();

            sceneData.enemyCount += 1;
        }
    }   

    public void Run()
    {
        foreach(var meow in _filter)
        {
            sceneData.positionsEnemy = sceneData.posEnemy.transform.GetComponentsInChildren<Transform>();
            sceneData.enemyCount = 0;

            foreach (var i in sceneData.positionsEnemy)
            {
                if (i.name == "SpawnEnemy") continue;
                if (i.name == "Check") continue;

                int temp = Random.Range(0, enemyObjects.Length);

                GameObject enemyObject = GameObject.Instantiate(enemyObjects[temp].enemyObject, i.position, Quaternion.identity);

                enemyObject.transform.SetParent(i);

                EcsEntity enemy = _world.NewEntity();

                ref EnemyData components = ref enemy.Get<EnemyData>();

                enemy.Get<EnemyNewFollow>();

                components.number = 0;
                components.hp = enemyObjects[temp].hp;
                components.name = enemyObjects[temp].name;
                components.transform = enemyObject.transform;
                components.rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();
                components.animator = enemyObject.GetComponent<Animator>();
                components.transform.GetComponent<EnemyShoot>().target = sceneData.playerPosition;
                components.timerForShoot = Random.Range(3, 6);

                enemyObject.GetComponent<EnemyShoot>().entity = enemy;
                enemyObject.GetComponent<EnemyShoot>().entityPlayer = sceneData.playerEntity;
                enemyObject.GetComponent<EnemyTrigger>().entity = enemy;
                enemyObject.GetComponent<EnemyTrigger>().sceneData = sceneData;
                enemyObject.GetComponent<EnemyTrigger>().ui = ui;

                components.targets = i.transform.GetComponentsInChildren<Transform>();

                sceneData.enemyCount += 1;
            }
        }
    }
}
