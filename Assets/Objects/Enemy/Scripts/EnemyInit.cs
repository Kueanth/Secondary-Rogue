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

    private int tempMax;
    private int[] mapping;

    public void Init()
    {
        sceneData.positionsEnemy = sceneData.posEnemy.transform.GetComponentsInChildren<Transform>();
        sceneData.enemyCount = 0;

        foreach(var i in sceneData.positionsEnemy)
        {
            if (i.name == "SpawnEnemy") continue;
            if (i.name == "Check") continue;

            mapping = new int[15] { 0,0,0,1,1,1,2,2,2,3,3,4,4,5,6 };

            if (sceneData.countLevel + 5 > 15)
                tempMax = 15;
            else
                tempMax = sceneData.countLevel + 5;

            int temp = Random.Range(sceneData.countLevel, tempMax);

            GameObject enemyObject = GameObject.Instantiate(enemyObjects[mapping[temp]].enemyObject, i.position, Quaternion.identity);

            enemyObject.transform.SetParent(i);

            EcsEntity enemy = _world.NewEntity();

            ref EnemyData components = ref enemy.Get<EnemyData>();

            enemy.Get<EnemyNewFollow>();

            components.number = 0;
            components.hp = enemyObjects[mapping[temp]].hp;
            components.name = enemyObjects[mapping[temp]].name;
            components.transform = enemyObject.transform;
            components.rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();
            components.animator = enemyObject.GetComponent<Animator>();
            components.transform.GetComponent<EnemyShoot>().target = sceneData.playerPosition;
            components.timerForShoot = Random.Range(3, 6);

            enemyObject.GetComponent<EnemyShoot>().entity = enemy;
            enemyObject.GetComponent<EnemyShoot>().entityPlayer = sceneData.playerEntity;
            enemyObject.GetComponent<EnemyTrigger>().gunEntity = sceneData.gunEntity;
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

                if (sceneData.countLevel + 5 > 15)
                    tempMax = 15;
                else
                    tempMax = sceneData.countLevel + 5;

                int temp = Random.Range(sceneData.countLevel, tempMax);

                GameObject enemyObject = GameObject.Instantiate(enemyObjects[mapping[temp]].enemyObject, i.position, Quaternion.identity);

                enemyObject.transform.SetParent(i);

                EcsEntity enemy = _world.NewEntity();

                ref EnemyData components = ref enemy.Get<EnemyData>();

                enemy.Get<EnemyNewFollow>();

                components.number = 0;
                components.hp = enemyObjects[mapping[temp]].hp;
                components.name = enemyObjects[mapping[temp]].name;
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
