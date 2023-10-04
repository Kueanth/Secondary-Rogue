using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class EnemyFollow : IEcsRunSystem
{
    private SceneData sceneData;

    private EcsFilter<EnemyData, EnemyNewFollow> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref EnemyData components = ref _filter.Get1(i);

            components.rigidbody2D.velocity = Vector2.zero;
            
            int temp = Random.Range(1, components.targets.Length);

            while(components.number == temp)
            {
                temp = Random.Range(1, components.targets.Length);
            }

            components.number = temp;

            components.rigidbody2D.velocity = new Vector2
                (components.targets[temp].position.x - components.transform.position.x,
                    components.targets[temp].position.y - components.transform.position.y).normalized;

            _filter.GetEntity(i).Del<EnemyNewFollow>();
        }
    }
}
