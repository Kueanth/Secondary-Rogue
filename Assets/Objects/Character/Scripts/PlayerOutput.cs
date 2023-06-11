using UnityEngine;
using Leopotam.Ecs;

public class PlayerOutput : IEcsRunSystem
{
    private EcsFilter<Player, Shoot> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player Components = ref _filter.Get1(i);

            Vector2 output = Vector2.zero;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(!Components.flipping)
                output = new Vector2(-4f, 0f);
            else
                output = new Vector2(4f, 0f);

            if (mousePosition.y > 0)
                output.y = -4f;
            else
                output.y = 4;

            Components.rigidbody2D.AddForce(output, ForceMode2D.Impulse);
            Components.light.intensity = 0f;
        }
    }
}
