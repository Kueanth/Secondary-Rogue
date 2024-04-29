using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.Rendering.Universal;

public class PlayerInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;
    private UI ui;

    private EcsFilter<RoomDestroy> _filter;

    private EcsWorld _world;

    public void Init()
    {
        PlayerInput.joystick = ui.joystick;

        EcsEntity Entity = _world.NewEntity();

        ref Player Components = ref Entity.Get<Player>();
        ref GunComponents gunComponents = ref Entity.Get<GunComponents>();

        GameObject PlayerObject = GameObject.Instantiate(configuration.Player, sceneData.playerSpawnPoint, Quaternion.identity);

        Components.hp = 3;
        Components.pit = false;
        Components.particleRun = true;
        Components.playerObject = PlayerObject;
        Components.transform = PlayerObject.GetComponent<Transform>();
        Components.rigidbody2D = PlayerObject.GetComponent<Rigidbody2D>();
        Components.animator = PlayerObject.GetComponent<Animator>();
        Components.spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();
        Components.particleSystem = PlayerObject.GetComponentInChildren<ParticleSystem>();

        Components.vignetteEffect = sceneData.vignetteEffect;

        PlayerObject.GetComponentInChildren<PlayerTrigger>().entity = Entity;
        PlayerObject.GetComponentInChildren<PlayerTrigger>().ui = ui;
        PlayerObject.GetComponentInChildren<PlayerTrigger>().sceneData = sceneData;
        PlayerObject.GetComponentInChildren<BodyTrigger>().ui = ui;
        PlayerObject.GetComponentInChildren<BodyTrigger>().entity = Entity;
        PlayerObject.GetComponentInChildren<BodyTrigger>().sceneData = sceneData;
        PlayerObject.GetComponent<PlayerLight>().components = gunComponents;
        PlayerObject.GetComponent<PlayerParticle>().entity = Entity;
        PlayerObject.GetComponent<PlayerParticle>().sceneData = sceneData;
        PlayerObject.GetComponent<PlayerParticle>().particleRun = true;

        Components.flip = true;

        sceneData.playerEntity = Entity;
        sceneData.playerPosition = Components.transform;
        sceneData.playerObject = PlayerObject;
        sceneData.ui = ui;

        sceneData.ui.deadScreen.playerTrigger = Components.transform.GetComponentInChildren<PlayerTrigger>();
        sceneData.ui.pausedScreen.sceneData = sceneData;
        sceneData.ui.pausedScreen.player = Entity;
        sceneData.ui.pausedScreen.ui = ui;

        sceneData.pointForPet = PlayerObject.transform.Find("Point");

        Progress.Instance.sceneData = this.sceneData;

        Components.transform.position = sceneData.playerSpawnPoint;
    }
}
