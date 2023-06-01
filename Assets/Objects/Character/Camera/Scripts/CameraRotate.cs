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

            Vector3 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerComponents.transform.position;
            Vector3 normDistance = distance.normalized;
            normDistance.z = -10;

            Debug.Log(normDistance);

            Vector3 temp = cameraComponents.transform.position;

            if (temp.x < 5f && temp.x > -5f && temp.y < 5f && temp.y > -5f)
                cameraComponents.transform.Translate(playerComponents.transform.position + distance);
            else if (temp.x < 1f && temp.x > -1f && temp.y < 1f && temp.y > -1f)
                cameraComponents.transform.Translate(playerComponents.transform.position);

        }
    }
}
