using UnityEngine;
using Leopotam.Ecs;
using System.Threading;

public class PlayerRotate : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            components.gun.rotation = Quaternion.LookRotation(Vector3.forward, mousePos);

            if (components.running)
                components.animator.SetBool("Running", true);
            else
                components.animator.SetBool("Running", false);

            if (components.flipping)
            {
                components.spriteRenderer.flipX = true;
            }
            else if (!components.flipping)
            {
                components.spriteRenderer.flipX = false;
            }
        }
    }
}
