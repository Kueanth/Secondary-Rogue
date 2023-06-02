using UnityEngine;
using Leopotam.Ecs;

public class CameraFollow : IEcsRunSystem
{
    private StaticData configuration;

    private EcsFilter<Player, CameraComponents> _filter;

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.2f;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref CameraComponents cameraComponents = ref _filter.Get2(i);
            ref Player playerComponents = ref _filter.Get1(i);

            if (!cameraComponents.rotation)
            {
                Vector3 target = playerComponents.transform.position;
                target.z = -10;

                cameraComponents.transform.position =
                    Vector3.SmoothDamp(cameraComponents.transform.position, target, ref velocity, smoothTime);
            }
        }
    }
}
