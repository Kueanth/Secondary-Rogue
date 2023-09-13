using UnityEngine;
using Leopotam.Ecs;

public class ChestInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    public void Init()
    {
        sceneData.positionsChests = sceneData.posChest.transform.GetComponentsInChildren<Transform>();

        foreach(var chest in sceneData.positionsChests)
        {
            if (chest.name == "SpawnChest") continue;

            EcsEntity chestEntity = _world.NewEntity();

            ref ChestData chestComponents = ref chestEntity.Get<ChestData>();

            GameObject chestObject = GameObject.Instantiate(configuration.Chest, chest.position, Quaternion.identity);

            chestObject.GetComponent<ChestTrigger>().entity = chestEntity;

            chestObject.transform.SetParent(chest);

            Material chestMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));
            
            chestObject.GetComponent<SpriteRenderer>().material = chestMaterial;

            chestObject.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
        }
    }
}
