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
            ref Player playerComponents = ref Player.Get<Player>();
 
            float randomX = 0;
            float randomY = 0;

            ref CameraComponents Components = ref _filter.Get1(i);

            float x = Components.transform.position.x;
            float y = Components.transform.position.y;
            float z = -10;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerComponents.transform.position;


            do
            {
                if (mousePosition.x > 0)
                {
                    randomX = -0.2f;
                    randomY = Random.Range(-0.2f, 0.2f);
                }
                else 
                {
                    randomX = 0.2f; ;
                    randomY = Random.Range(-0.2f, 0.2f);
                }
            }
            while (randomY == 0f);

            Components.transform.position = new Vector3(x + randomX, y + randomY, z);

            Player.Del<Shoot>();
        }
    }
}
