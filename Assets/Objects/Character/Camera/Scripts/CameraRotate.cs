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

            Vector3 temp = distance;

            if (temp.x < 10f && temp.x > -10f && temp.y < 10f && temp.y > -10f)
                cameraComponents.rigidbody2D.velocity = normDistance * 10f;
            else
                cameraComponents.rigidbody2D.velocity = Vector2.zero;

        }
    }
}
