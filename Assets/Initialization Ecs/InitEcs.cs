using UnityEngine;
using Leopotam.Ecs;

public class InitEcs : MonoBehaviour
{
    [SerializeField] public SceneData sceneData;
    [SerializeField] public StaticData configuration;

    private EcsWorld _world;

    private EcsSystems _startSystems;
    private EcsSystems _fixedSystems;
    private EcsSystems _updateSystems;
    private EcsSystems _lateSystems;

    private void Awake()
    {
        _world = new EcsWorld();

        _startSystems = new EcsSystems(_world);
        _fixedSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _lateSystems = new EcsSystems(_world);

        _startSystems
            .Add(new PlayerInit())
            .Inject(sceneData)
            .Inject(configuration)
            .Init();

        _fixedSystems
            .Init();

        _updateSystems
            .Add(new PlayerInput())
            .Init();

        _lateSystems
            .Init();
    }

    private void Start()
    {
        _startSystems.Run();
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
        _startSystems.Destroy();
        _fixedSystems.Destroy();
        _updateSystems.Destroy();
        _lateSystems.Destroy();
    }
}
