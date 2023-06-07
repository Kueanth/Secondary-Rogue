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

            // Get mouse position and set rotation for hand
            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            components.gun.rotation = Quaternion.LookRotation(Vector3.forward, positionMouse);

            // Set bool for animator
            if (components.running)

                components.animator.SetBool("Running", true);
            else
                components.animator.SetBool("Running", false);

            // flipping character
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
