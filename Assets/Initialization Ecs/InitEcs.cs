using UnityEngine;
using Leopotam.Ecs;

public class InitEcs : MonoBehaviour
{
    [SerializeField] private SceneData sceneData; // MonoBehaviour
    [SerializeField] private StaticData configuration; // ScriptableObject
    [SerializeField] private UI ui; // User Interface Components 
    [SerializeField] private RoomData rooms; // Rooms for Initialization

    private EcsWorld _world;

    private EcsSystems _awakeSystems;
    private EcsSystems _startSystems;
    private EcsSystems _fixedSystems;
    private EcsSystems _updateSystems;
    private EcsSystems _lateSystems;

    private void Awake()
    {

        _world = new EcsWorld();

        _awakeSystems = new EcsSystems(_world);
        _startSystems = new EcsSystems(_world);
        _fixedSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _lateSystems = new EcsSystems(_world);

        _awakeSystems
            .Init();

        _startSystems
            .Add(new FadeInit())
            .Add(new PlayerInit())
            .Add(new CameraInit())
            .Add(new EnemyInit())
            .Add(new ChestInit())
            .Add(new HatchInit())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui)
            .Init();

        _fixedSystems
            .Init();

        _updateSystems
            .Add(new PlayerInput())
            .Add(new PlayerRotate())
            .Add(new CameraFollow())
            .Add(new BulletShoot())
            .Add(new PlayerOutput())
            .Add(new EnemyFollow())
            .Add(new EnemyInput())
            .Inject(configuration)
            .Inject(sceneData)
            .Init();

        _lateSystems
            .Add(new AimFollow())
            .Add(new CameraTrembling())
            .Inject(ui)
            .Init();

        _awakeSystems.Run();
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
        _awakeSystems.Destroy();
        _startSystems.Destroy();
        _fixedSystems.Destroy();
        _updateSystems.Destroy();
        _lateSystems.Destroy();
    }
}
