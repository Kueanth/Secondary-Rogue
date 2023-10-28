using UnityEngine;
using Leopotam.Ecs;

public class AimFollow : IEcsRunSystem, IEcsInitSystem
{
    private UI ui;
    private SceneData sceneData;
    private StaticData configuration;
    private EcsWorld _world;

    public void Init()
    {
        Cursor.SetCursor(configuration.Cursor, Vector2.zero, CursorMode.Auto);
        Cursor.visible = false;
    }

    public void Run()
    {
        // For cursor

        if (Cursor.visible && !sceneData.paused) Cursor.visible = false;
        else if (!Cursor.visible && sceneData.paused) Cursor.visible = true;

        ui.gameScreen.aim.transform.position = Input.mousePosition;
    }
}
