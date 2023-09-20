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
            ref EcsEntity entity = ref _filter.GetEntity(i);

            ref CameraComponents cameraComponents = ref entity.Get<CameraComponents>();
            ref GunComponents gunComponents = ref entity.Get<GunComponents>();

            // Get mouse position and set rotation for hand
            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gunComponents.gun.transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            gunComponents.gun.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

            // Set bool for animator
            if (components.running)

                components.animator.SetBool("Running", true);
            else
                components.animator.SetBool("Running", false);

            // flipping character
            if (components.flipping)
            {
                components.spriteRenderer.flipX = true;
                gunComponents.flipGun.flipY = true;

            }
            else if (!components.flipping)
            {
                components.spriteRenderer.flipX = false;
                gunComponents.flipGun.flipY = false;
            }
        }
    }
}
