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

            if (temp.x > 3f || temp.x < -3f && temp.y > 3f || temp.y < -3f)
            {
                Vector3 pos = cameraComponents.transform.position - playerComponents.transform.position;

                Vector3 maxRadius = new Vector3(7f, -7f, 0f);

                if (pos.x < maxRadius.x && pos.x > maxRadius.y && pos.y < maxRadius.x && pos.y > maxRadius.y)
                {
                    cameraComponents.rigidbody2D.velocity = normDistance * 10f;
                    cameraComponents.rotation = true;
                }
                else
                {
                    float x = Mathf.Clamp(pos.x, -7f, 7f);
                    float y = Mathf.Clamp(pos.y, -7f, 7f);

                    cameraComponents.transform.position = new Vector3(x, y, -10);
                }
            }
            else
            {
                cameraComponents.rigidbody2D.velocity = Vector2.zero;
                cameraComponents.rotation = false;
            }
        }
    }
}
