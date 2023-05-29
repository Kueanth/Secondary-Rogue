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

            if (horizontal <= -0.5f && vertical <= -0.5f)
            {
                components.animator.SetBool("Running", true);
                components.spriteRenderer.flipX = true;
            }
            else if (horizontal >= 0.5f && vertical >= 0.5f)
            {
                components.animator.SetBool("Running", true);
                components.spriteRenderer.flipX = false;
            }
            else if (horizontal >= 0.5f || vertical >= 0.5f)
            {
                components.animator.SetBool("Running", true);
                components.spriteRenderer.flipX = false;
            }
            else if (horizontal <= -0.5f || vertical <= -0.5f)
            {
                components.animator.SetBool("Running", true);
                components.spriteRenderer.flipX = true;
            }
            else
            {
                components.animator.SetBool("Running", false);
            }
        }
    }
}
