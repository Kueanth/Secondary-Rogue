using UnityEngine;
using Leopotam.Ecs;

public class CameraFollow : IEcsRunSystem
{
    private EcsFilter<Player, CameraComponents> _filter;

    private StaticData configuration;

    private Vector3 velocity = Vector3.zero;

    private float smoothTime = 0.2f;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref CameraComponents CameraComponents = ref _filter.Get2(i);
            ref Player PlayerComponents = ref _filter.Get1(i);

            Vector3 target = PlayerComponents.transform.position;
            target.z = -10;

            Vector3 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - CameraComponents.transform.position;
            distance.Normalize();
            distance.z = -10;

            CameraComponents.transform.position =
            Vector3.SmoothDamp(CameraComponents.transform.position, target + (distance * 2f), ref velocity, smoothTime);
        }
    }
}
