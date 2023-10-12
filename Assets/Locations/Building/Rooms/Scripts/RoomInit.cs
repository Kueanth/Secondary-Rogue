using UnityEngine;
using Leopotam.Ecs;

public class RoomInit : IEcsInitSystem, IEcsRunSystem
{
    public RoomData rooms;
    public SceneData sceneData;

    private EcsWorld _world;

    private int meow;

    private EcsFilter<RoomDestroy, RoomCreate> _filter;

    public void Init()
    {
        sceneData.levelComplete = false;

        EcsEntity entity = _world.NewEntity();
        ref RoomDestroy gow = ref entity.Get<RoomDestroy>();

        ref Player componentsPlayer = ref sceneData.playerEntity.Get<Player>();

        int temp = Random.Range(0, rooms.Rooms.Length);

        componentsPlayer.transform.position = rooms.Rooms[temp].spawnPositionPlayer;

        GameObject roomObject = GameObject.Instantiate(rooms.Rooms[temp].RoomPrefab, Vector2.zero, Quaternion.identity);

        sceneData.roomEntity = entity;

        gow.room = roomObject;

        sceneData.posChest = roomObject.transform.Find("SpawnChest");
        sceneData.posEnemy = roomObject.transform.Find("SpawnEnemy");
        sceneData.posHatch = roomObject.transform.Find("SpawnHatch");
    }

    public void Run()
    {
        foreach(var meow in _filter)
        {
            sceneData.levelComplete = false;

            ref RoomDestroy gow = ref _filter.Get1(meow);
            EcsEntity entity = _filter.GetEntity(meow);

            ref Player componentsPlayer = ref sceneData.playerEntity.Get<Player>();

            GameObject.Destroy(gow.room);

            int temp = Random.Range(0, rooms.Rooms.Length);

            componentsPlayer.transform.position = rooms.Rooms[temp].spawnPositionPlayer;

            GameObject roomObject = GameObject.Instantiate(rooms.Rooms[temp].RoomPrefab, Vector2.zero, Quaternion.identity);

            gow.room = roomObject;

            sceneData.posChest = roomObject.transform.Find("SpawnChest");
            sceneData.posEnemy = roomObject.transform.Find("SpawnEnemy");
            sceneData.posHatch = roomObject.transform.Find("SpawnHatch");         
        }
    }
}
