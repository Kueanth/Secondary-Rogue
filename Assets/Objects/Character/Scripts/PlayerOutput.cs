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

            Components.rigidbody2D.AddForce(new Vector2(mousePosition.x - Components.transform.position.x, mousePosition.y - Components.transform.position.y).normalized * -5f, ForceMode2D.Impulse);
        }
    }
}
