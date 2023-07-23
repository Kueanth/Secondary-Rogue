using UnityEngine;
using Leopotam.Ecs;
using System.Threading;

public class BulletShoot : IEcsRunSystem
{
    private EcsFilter<Player, Shoot> _filter;

    private StaticData configuration;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref Player components = ref _filter.Get1(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);

            GameObject bulletObject = null;

            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - components.gun.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ + 90f);

            if (!components.flipping)
            {
                bulletObject =
                    GameObject.Instantiate(configuration.Bullet, components.bulletSpawn.position, rotation);
            }
            else if (components.flipping)
            {
                Vector2 temp = new Vector2(components.bulletSpawn.position.x, components.bulletSpawn.position.y + 0.25f);

                 bulletObject =
                    GameObject.Instantiate(configuration.Bullet, temp, rotation);
            }

            ParticleSystem ps = bulletObject.GetComponent<ParticleSystem>();
            ps.
            BulletTrigger bo = bulletObject.GetComponent<BulletTrigger>();
            bo.particle = ps;

            Rigidbody2D bpl = bulletObject.GetComponent<Rigidbody2D>();

            bpl.velocity = components.bulletSpawn.right * 20f;
        }
    }
}
