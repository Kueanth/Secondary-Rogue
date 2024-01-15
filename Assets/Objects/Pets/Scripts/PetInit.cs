using UnityEngine;
using Leopotam.Ecs;

public class PetInit : IEcsInitSystem
{
    private EcsWorld _world;

    private EcsEntity player;

    private StaticData configuration;
    private SceneData sceneData;

    public void Init()
    {
        player = sceneData.playerEntity; 

        EcsEntity entity = _world.NewEntity();

        ref PetData data = ref entity.Get<PetData>();

        Debug.Log(sceneData.pointForPet.position);

        GameObject Pet =
            GameObject.Instantiate
                (configuration.Pets[Progress.Instance.PlayerInfoForSave.pet], sceneData.pointForPet.position, Quaternion.identity);

        data.Pet = Pet;
        data.Transform = Pet.transform;
        data.Script = Pet.GetComponent<PetInMenu>();
        data.Rigidbody = Pet.GetComponent<Rigidbody2D>();
        data.Animator = Pet.GetComponent<Animator>();

        sceneData.Pet = Pet;

        Pet.GetComponent<PetInMenu>().target = sceneData.pointForPet;

        Pet.transform.localScale = new Vector2(0.8f, 0.8f);

        Debug.Log(sceneData.playerSpawnPoint);
        data.Transform.transform.position = sceneData.pointForPet.position;
    }
}
