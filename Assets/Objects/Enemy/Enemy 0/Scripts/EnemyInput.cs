using UnityEngine;
using Leopotam.Ecs;

public class EnemyInput : IEcsRunSystem
{
    private EcsFilter<EnemyData> _filter;

    private float timer = 5f;

    public void Run()
    {
        foreach(var i in _filter)
        {
            if (timer <= 0f)
            {
                ref Animator animator = ref _filter.Get1(i).animator;
                timer = Random.Range(3,6);
                animator.SetBool("Attack", true);
            }
            else
            {
                ref Animator animator = ref _filter.Get1(i).animator;
                timer -= Time.deltaTime;
                animator.SetBool("Attack", false);
            }
        }
    }
}
