using UnityEngine;
using Leopotam.Ecs;

public class CameraRotate : IEcsRunSystem
{
    private StaticData configuration;

    private EcsFilter<Player, CameraComponents> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player playerComponents = ref _filter.Get1(i);
            ref CameraComponents cameraComponents = ref _filter.Get2(i);

            Vector2 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerComponents.transform.position;
            Vector2 normDistance = distance.normalized;

            Debug.Log(normDistance);
        }
    }
}
