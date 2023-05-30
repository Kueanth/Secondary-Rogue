using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField] private Image aim;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        aim.rectTransform.transform.position = Input.mousePosition;
    }
}
