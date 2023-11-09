using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class InitYandex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;

    [DllImport("__Internal")]
    private static extern void GetDataPlayer();

    public void Start()
    {
        // GetDataPlayer();
    }

    public void GetData(string name)
    {
        _name.text = name;
    }
}
