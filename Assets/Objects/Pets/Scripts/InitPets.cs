using UnityEngine;

public class InitPets : MonoBehaviour
{
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject[] Pets;
    [SerializeField] private Transform Point;

    [SerializeField] private GameObject Pet;
    [SerializeField] private GameObject Character;
    [SerializeField] private Shop Shop;

    public void InitializationPets()
    {
        switch (Progress.Instance.PlayerInfoForSave.pet)
        {
            case 0:
                Pet = GameObject.Instantiate(Pets[0], Point.position, Quaternion.identity);
                break;

            case 1:
                Pet = GameObject.Instantiate(Pets[1], Point.position, Quaternion.identity);
                break;

            case 2:
                Pet = GameObject.Instantiate(Pets[2], Point.position, Quaternion.identity);
                break;

            case 3:
                Pet = GameObject.Instantiate(Pets[3], Point.position, Quaternion.identity);
                break;

            case 4:
                Pet = GameObject.Instantiate(Pets[4], Point.position, Quaternion.identity);
                break;

            case 5:
                Pet = GameObject.Instantiate(Pets[5], Point.position, Quaternion.identity);
                break;
        }

        Pet.GetComponent<PetInMenu>().target = Point;
        Character.GetComponent<Character>().Pet = Pet.GetComponent<SpriteRenderer>();
        Pet.transform.SetParent(Parent);
    }

    public void Delete()
    {
        GameObject.Destroy(Pet);
        InitializationPets();
    }
}
