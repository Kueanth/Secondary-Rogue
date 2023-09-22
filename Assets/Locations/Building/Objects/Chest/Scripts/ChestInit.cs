using UnityEngine;
using Leopotam.Ecs;

public class ChestInit : IEcsInitSystem, IEcsRunSystem
{
    private SceneData sceneData;
    private StaticData configuration;
    private EcsEntity roomEntity;
    private EcsFilter<RoomDestroy, RoomCreate> _filter;
    private GunArray guns;
    private UI ui;

    private EcsWorld _world;

    public void Init()
    {
        sceneData.positionsChests = sceneData.posChest.transform.GetComponentsInChildren<Transform>();

        foreach (var chest in sceneData.positionsChests)
        {
            if (chest.name == "SpawnChest") continue;

            int random = Random.Range(0, 2);

            if (random != 0) continue;

            EcsEntity chestEntity = _world.NewEntity();

            ref ChestData chestComponents = ref chestEntity.Get<ChestData>();

            random = Random.Range(0, guns.guns.Length);

            chestComponents.gun = guns.guns[random].nameGun;
            chestComponents.gunData = guns.guns[random];
            chestComponents.prefabGun = guns.guns[random].prefabForChest;

            GameObject chestObject = GameObject.Instantiate(configuration.Chest, chest.position, Quaternion.identity);

            chestComponents.transformForGun = chest.position;
            chestComponents.open = false;
            chestComponents.animator = chestObject.GetComponent<Animator>();

            chestObject.GetComponentInChildren<ChestTrigger>().ui = ui;

            chestObject.GetComponentInChildren<ChestTrigger>().entity = chestEntity;

            chestObject.transform.SetParent(chest);

            Material chestMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

            chestMaterial.SetVector("_Right", new Vector2(0f, 0f));
            chestMaterial.SetVector("_Left", new Vector2(0f, 0f));
            chestMaterial.SetVector("_Up", new Vector2(0f, 0f));
            chestMaterial.SetVector("_Down", new Vector2(0f, 0f));

            chestMaterial.color = new Color32(0, 0, 0, 0);

            chestObject.GetComponent<SpriteRenderer>().material = chestMaterial;
        }
    }

    public void Run()
    {
        foreach (var meow in _filter)
        {
            sceneData.positionsChests = sceneData.posChest.transform.GetComponentsInChildren<Transform>();

            foreach (var chest in sceneData.positionsChests)
            {
                if (chest.name == "SpawnChest") continue;

                int random = Random.Range(0, 2);

                if (random != 0)
                    continue;

                EcsEntity chestEntity = _world.NewEntity();

                ref ChestData chestComponents = ref chestEntity.Get<ChestData>();

                random = Random.Range(0, guns.guns.Length);

                chestComponents.gun = guns.guns[random].nameGun;
                chestComponents.gunData = guns.guns[random];
                chestComponents.prefabGun = guns.guns[random].prefabForChest;

                GameObject chestObject = GameObject.Instantiate(configuration.Chest, chest.position, Quaternion.identity);

                chestComponents.transformForGun = chest.position;
                chestComponents.open = false;
                chestComponents.animator = chestObject.GetComponent<Animator>();

                chestObject.GetComponentInChildren<ChestTrigger>().entity = chestEntity;

                chestObject.GetComponentInChildren<ChestTrigger>().ui = ui;

                chestObject.transform.SetParent(chest);

                Material chestMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

                chestMaterial.SetVector("_Right", new Vector2(0f, 0f));
                chestMaterial.SetVector("_Left", new Vector2(0f, 0f));
                chestMaterial.SetVector("_Up", new Vector2(0f, 0f));
                chestMaterial.SetVector("_Down", new Vector2(0f, 0f));

                chestMaterial.color = new Color32(0, 0, 0, 0);

                chestObject.GetComponent<SpriteRenderer>().material = chestMaterial;

                EcsEntity roomEntity = _filter.GetEntity(meow);
                roomEntity.Del<RoomCreate>();
            }

            roomEntity = _filter.GetEntity(0);
            roomEntity.Del<RoomCreate>();
        }
    }
}
