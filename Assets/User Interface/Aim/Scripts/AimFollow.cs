using UnityEngine;
using Leopotam.Ecs;

public class AimFollow : IEcsRunSystem
{
    private UI ui;

    private EcsWorld _world;

    public void Run()
    {
        // For cursor

        if (Cursor.visible) Cursor.visible = false;

        ui.gameScreen.aim.transform.position = Input.mousePosition;
    }
}
