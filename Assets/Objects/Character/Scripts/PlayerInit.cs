using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.Rendering.Universal;

public class PlayerInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;
    private GunArray gunArray;
    private UI ui;

    private EcsFilter<RoomDestroy> _filter;

    private EcsWorld _world;

    public void Init()
    {
        EcsEntity Entity = _world.NewEntity();

        ref Player Components = ref Entity.Get<Player>();
        ref GunComponents gunComponents = ref Entity.Get<GunComponents>();

        GameObject PlayerObject = GameObject.Instantiate(configuration.Player, sceneData.playerSpawnPoint, Quaternion.identity);

        Components.hp = 100;
        Components.pit = false;
        Components.playerObject = PlayerObject;
        Components.transform = PlayerObject.GetComponent<Transform>();
        Components.rigidbody2D = PlayerObject.GetComponent<Rigidbody2D>();
        Components.animator = PlayerObject.GetComponent<Animator>();
        Components.spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();

        Components.vignetteEffect = sceneData.vignetteEffect;

        PlayerObject.GetComponentInChildren<PlayerTrigger>().entity = Entity;
        PlayerObject.GetComponentInChildren<BodyTrigger>().entity = Entity;
        PlayerObject.GetComponent<PlayerLight>().components = gunComponents;

        Components.flip = true;

        sceneData.playerEntity = Entity;
        sceneData.playerPosition = Components.transform;
    }
}
