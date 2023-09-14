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

            chestComponents.open = false;
            chestComponents.animator = chestObject.GetComponent<Animator>();

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
}
