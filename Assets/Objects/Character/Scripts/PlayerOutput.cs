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

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Components.flipping)
            {
                Components.rigidbody2D.AddForce(mousePosition.normalized * -5f, ForceMode2D.Impulse);
            }
            else
            {
                Components.rigidbody2D.AddForce(mousePosition.normalized * 5f, ForceMode2D.Impulse);
            }
        }
    }
}
