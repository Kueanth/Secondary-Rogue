using UnityEngine;
using Leopotam.Ecs;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);

            float horizontal = Input.GetAxis("Horizontal") * 4f;
            float vertical = Input.GetAxis("Vertical") * 4f;

            components.rigidbody2D.velocity = new Vector2(horizontal, vertical);

            if (horizontal >= 0.2f || vertical >= 0.2f || vertical <= -0.2f || horizontal <= -0.2f)
            {
                components.animator.SetBool("Running", true);
            }
            else
            {
                components.animator.SetBool("Running", false);
            }

            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - components.transform.position;

            if(positionMouse.x < 0)
            {
                components.spriteRenderer.flipX = true;
            }
            else
            {
                components.spriteRenderer.flipX = false;
            }
            
            
        }
    }
}
