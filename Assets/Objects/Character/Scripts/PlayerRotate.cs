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
            float rotateZ = Mathf.Atan2(positionMouse.y, positionMouse.x) * Mathf.Rad2Deg;
            components.gun.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

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
