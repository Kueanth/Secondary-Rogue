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

            Vector2 output = new Vector2(-1f, 0f);

            Components.rigidbody2D.AddForce(output, ForceMode2D.Impulse);
        }
    }
}
