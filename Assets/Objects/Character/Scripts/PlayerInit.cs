using UnityEngine;
using Leopotam.Ecs;

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
        Components.transform = PlayerObject.GetComponent<Transform>();
        Components.rigidbody2D = PlayerObject.GetComponent<Rigidbody2D>();
        Components.animator = PlayerObject.GetComponent<Animator>();
        Components.spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();

        Components.flip = true;

        // Child Object Components
        Components.gun = PlayerObject.transform.Find("Gun");
        Components.bulletSpawn = Components.gun.Find("Spawn Bullet");
        Components.flipGun = Components.gun.GetComponent<SpriteRenderer>();
    }
}
