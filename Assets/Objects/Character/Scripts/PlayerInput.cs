using UnityEngine;
using Leopotam.Ecs;

public class PlayerInput : IEcsRunSystem
{
    private EcsFilter<Player> _filter;

    public float speed = 4f;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);

            float horizontal = Input.GetAxis("Horizontal") * speed;
            float vertical = Input.GetAxis("Vertical") * speed;

            components.rigidbody2D.velocity = new Vector2(horizontal, vertical);

            Vector3 meow = components.transform.position;

            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if(positionMouse.y > 0)
            {

            }

            if (positionMouse.x < 0)
            {
                components.flipping = true;
                components.flipGun.flipX = true;
                components.gun.position = new Vector3(meow.x + -0.24f, meow.y + -0.17f, 0f);
            }
            else
            {
                components.flipping = false;
                components.flipGun.flipX = false;
                components.gun.position = new Vector3(meow.x + 0.27f, meow.y + -0.17f, 0f);
            }
            
            if(vertical >= 0.2f || vertical <= -0.2f)
            {
                components.running = true;
            }

            if (horizontal >= 0.2f)
            {
                components.running = true;
                components.flipping = false;
            }
            else if (horizontal <= -0.2f)
            {
                components.running = true;
                components.flipping = true;
            }
            else
            {
                if (vertical >= 0.2f || vertical <= -0.2f)
                {
                    components.running = true;
                }
                else
                {
                    components.running = false;
                }
            }
        }
    }
}
