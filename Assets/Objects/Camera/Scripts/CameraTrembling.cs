using UnityEngine;
using Leopotam.Ecs;

public class CameraTrembling : IEcsRunSystem
{
    private EcsFilter<CameraComponents, Shoot> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            EcsEntity Player = _filter.GetEntity(i);

            float randomX = 0;
            float randomY = 0;

            ref CameraComponents Components = ref _filter.Get1(i);

            float x = Components.transform.position.x;
            float y = Components.transform.position.y;
            float z = -10;

            do
            {
                randomX = Random.Range(-0.2f, 0.2f);
                randomY = Random.Range(-0.2f, 0.2f);
            }
            while (randomX == 0 && randomY == 0);

            Components.transform.position = new Vector3(x + randomX, y + randomY, z);

            Player.Del<Shoot>();
        }
    }
}
