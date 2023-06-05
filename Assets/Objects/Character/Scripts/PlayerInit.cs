using UnityEngine;
using Leopotam.Ecs;

public class PlayerInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    public void Init()
    {
        EcsEntity playerEntity = _world.NewEntity();

        ref Player Components = ref playerEntity.Get<Player>();
        ref CameraComponents CameraComponents = ref playerEntity.Get<CameraComponents>();

        GameObject PlayerObject = GameObject.Instantiate(configuration.Player, sceneData.spawnPointPlayer, Quaternion.identity);
        GameObject CameraObject = GameObject.Instantiate(configuration.Camera, sceneData.spawnPointPlayer, Quaternion.identity);

        Components.transform = PlayerObject.GetComponent<Transform>();
        Components.rigidbody2D = PlayerObject.GetComponent<Rigidbody2D>();
        Components.animator = PlayerObject.GetComponent<Animator>();
        Components.spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();

        Transform meow = PlayerObject.transform.Find("Square");

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        meow.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - meow.transform.position);

        CameraComponents.transform = CameraObject.GetComponent<Transform>();
        CameraComponents.rigidbody2D = CameraObject.GetComponent<Rigidbody2D>();
    }
}
