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
    }

    public void Run()
    {
        // For cursor

        if (Cursor.visible && !sceneData.paused) Cursor.visible = false;
        else if (!Cursor.visible && sceneData.paused || Progress.Instance.openPausedBar) Cursor.visible = true;

        if (sceneData.paused)
        {
            ui.gameScreen.aim.enabled = false;
        }
        else
        {
            ui.gameScreen.aim.enabled = true;
            ui.gameScreen.aim.transform.position = Input.mousePosition;
        }
    }
}
