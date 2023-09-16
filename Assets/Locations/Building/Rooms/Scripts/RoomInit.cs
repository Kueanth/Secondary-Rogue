using UnityEngine;
using Leopotam.Ecs;

public class RoomInit : IEcsRunSystem
{
    public RoomData roomData;
    public SceneData sceneData;

    private EcsFilter<RoomCreate> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            
        }
    }
}
