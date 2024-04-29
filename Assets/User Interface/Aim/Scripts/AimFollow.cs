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

        sceneData.paused = false;
        Cursor.visible = true;
    }

    public void Run()
    {
        // For cursor
        if(!sceneData.paused)
        {
            if(!sceneData.lazerWork)
                ui.gameScreen.aim.enabled = true;
            else if(sceneData.lazerWork)
                ui.gameScreen.aim.enabled = false;

            Cursor.visible = false;
        }
        else if(sceneData.paused)
        {
            ui.gameScreen.aim.enabled = false;

            Cursor.SetCursor(configuration.Cursor, Vector2.zero, CursorMode.Auto);
            Cursor.visible = true;
        }

        if (!sceneData.paused && ui.gameScreen.aim.enabled)
        {
            if (!Progress.Instance.mobile)
            {
                ui.gameScreen.aim.transform.position = Input.mousePosition;
            }
        }
    }
}
