using UnityEngine;
using Leopotam.Ecs;

public class HatchInit : IEcsInitSystem, IEcsRunSystem
{
    private SceneData sceneData;
    private StaticData configuration;
    private UI ui;

    private EcsFilter<RoomDestroy, RoomCreate> _filter;

    private EcsWorld _world;

    public void Init()
    {
        sceneData.positionsHatchs = sceneData.posHatch.transform.GetComponentsInChildren<Transform>();

        int temp = 0;

        foreach (var hatch in sceneData.positionsHatchs)
        {
            if (hatch.name == "SpawnHatch") continue;

            EcsEntity hatchEntity = _world.NewEntity();

            ref Hatch hatchComponents = ref hatchEntity.Get<Hatch>();

            GameObject hatchObject = GameObject.Instantiate(configuration.Hatch, hatch.position, Quaternion.identity);

            sceneData.hatchs[temp] = hatchObject;
            ++temp;

            hatchComponents.open = false;
            hatchComponents.animator = hatchObject.GetComponent<Animator>();

            hatchObject.GetComponentInChildren<HatchTrigger>().entity = hatchEntity;
            hatchObject.GetComponentInChildren<HatchTrigger>().sceneData = sceneData;
            hatchObject.GetComponentInChildren<HatchTrigger>().ui = ui;

            hatchObject.transform.SetParent(hatch);

            Material hatchMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

            hatchMaterial.SetVector("_Right", new Vector2(0f, 0f));
            hatchMaterial.SetVector("_Left", new Vector2(0f, 0f));
            hatchMaterial.SetVector("_Up", new Vector2(0f, 0f));
            hatchMaterial.SetVector("_Down", new Vector2(0f, 0f));

            hatchMaterial.color = new Color32(0, 0, 0, 0);

            hatchObject.GetComponent<SpriteRenderer>().material = hatchMaterial;
        }
    }

    public void Run()
    {
        foreach(var meow in _filter)
        {
            sceneData.positionsHatchs = sceneData.posHatch.transform.GetComponentsInChildren<Transform>();

            int temp = 0;

            foreach (var hatch in sceneData.positionsHatchs)
            {
                if (hatch.name == "SpawnHatch") continue;

                EcsEntity hatchEntity = _world.NewEntity();

                ref Hatch hatchComponents = ref hatchEntity.Get<Hatch>();

                GameObject hatchObject = GameObject.Instantiate(configuration.Hatch, hatch.position, Quaternion.identity);

                sceneData.hatchs[temp] = hatchObject;
                ++temp;

                hatchComponents.open = false;
                hatchComponents.animator = hatchObject.GetComponent<Animator>();

                hatchObject.GetComponentInChildren<HatchTrigger>().entity = hatchEntity;
                hatchObject.GetComponentInChildren<HatchTrigger>().sceneData = sceneData;
                hatchObject.GetComponentInChildren<HatchTrigger>().ui = ui;

                hatchObject.transform.SetParent(hatch);

                Material hatchMaterial = new Material(Shader.Find("Shader Graphs/Outlines"));

                hatchMaterial.SetVector("_Right", new Vector2(0f, 0f));
                hatchMaterial.SetVector("_Left", new Vector2(0f, 0f));
                hatchMaterial.SetVector("_Up", new Vector2(0f, 0f));
                hatchMaterial.SetVector("_Down", new Vector2(0f, 0f));

                hatchMaterial.color = new Color32(0, 0, 0, 0);

                hatchObject.GetComponent<SpriteRenderer>().material = hatchMaterial;
            }
        }
    }
}
