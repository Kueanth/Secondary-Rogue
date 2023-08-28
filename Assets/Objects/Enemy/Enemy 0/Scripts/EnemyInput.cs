using UnityEngine;
using Leopotam.Ecs;

public class EnemyInput : IEcsRunSystem
{
    private EcsFilter<EnemyData> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref EnemyData components = ref _filter.Get1(i);
            float timer = components.timerForShoot;
            Animator animator = components.animator;

            if (timer <= 0f)
            {
                components.timerForShoot = Random.Range(3,6);
                animator.SetBool("Attack", true);
            }
            else
            {
                components.timerForShoot -= Time.deltaTime;
                animator.SetBool("Attack", false);
            }
        }
    }
}
