using UnityEngine;
using Leopotam.Ecs;

public class CameraInit : IEcsInitSystem
{
    private EcsFilter<Player> _filter;

    private StaticData configuration;
    private SceneData sceneData;

    public void Init()
    {
        foreach(var i in _filter)
        {
            ref Player Components = ref _filter.Get1(i);

            EcsEntity Entity = _filter.GetEntity(i);

            ref CameraComponents CameraComponents = ref Entity.Get<CameraComponents>();

            GameObject CameraObject = GameObject.Instantiate(configuration.Camera, sceneData.playerSpawnPoint, Quaternion.identity);

            CameraComponents.transform = CameraObject.GetComponent<Transform>();
            CameraComponents.rigidbody2D = CameraObject.GetComponent<Rigidbody2D>();

        }
    }
}
