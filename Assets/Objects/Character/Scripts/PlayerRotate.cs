using UnityEngine;
using Leopotam.Ecs;

public class PlayerRotate : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);

            if(components.running)
                components.animator.SetBool("Running", true);
            else
                components.animator.SetBool("Running", false);

            if (components.flipping && !components.running)
                components.spriteRenderer.flipX = true;
            else if (components.flipping && !components.running)
                components.spriteRenderer.flipX = false;
        }
    }
}
