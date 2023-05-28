using UnityEngine;
using Leopotam.Ecs;

public class InitEcs : MonoBehaviour
{
    [SerializeField] private SceneData sceneData;
    [SerializeField] private StaticData configuration;

    private EcsWorld _world;

    private EcsSystems _fixedSystems;
    private EcsSystems _updateSystems;
    private EcsSystems _lateSystems;

    private void Awake()
    {
        _world = new EcsWorld();

        _fixedSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _lateSystems = new EcsSystems(_world);
    }

    private void FixedUpdate()
    {
        _fixedSystems.Run();
    }

    private void Update()
    {
        _updateSystems.Run();
    }

    private void LateUpdate()
    {
        _lateSystems.Run();
    }

    private void OnDestroy()
    {
        _fixedSystems.Destroy();
        _updateSystems.Destroy();
        _lateSystems.Destroy();
    }
}
