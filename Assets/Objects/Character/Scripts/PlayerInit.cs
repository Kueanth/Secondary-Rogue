using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.Rendering.Universal;

public class PlayerInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    public void Init()
    {
        EcsEntity Entity = _world.NewEntity();

        ref Player Components = ref Entity.Get<Player>();

        GameObject PlayerObject = GameObject.Instantiate(configuration.Player, sceneData.playerSpawnPoint, Quaternion.identity);

        // Main Object Components
        Components.hp = 100;
        Components.pit = false;
        Components.playerObject = PlayerObject;
        Components.transform = PlayerObject.GetComponent<Transform>();
        Components.rigidbody2D = PlayerObject.GetComponent<Rigidbody2D>();
        Components.animator = PlayerObject.GetComponent<Animator>();
        Components.spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();

        PlayerObject.GetComponentInChildren<PlayerTrigger>().entity = Entity;
        PlayerObject.GetComponentInChildren<BodyTrigger>().entity = Entity;

        Components.flip = true;
        sceneData.playerPosition = Components.transform;

        // Child Object Components
        Components.gun = PlayerObject.transform.Find("Gun");
        Components.light = Components.gun.Find("Light").GetComponent<Light2D>();
        Components.bulletSpawn = Components.gun.Find("Spawn Bullet");
        Components.flipGun = Components.gun.GetComponent<SpriteRenderer>();
    }
}
