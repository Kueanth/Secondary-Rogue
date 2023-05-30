using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Texture2D aim;

    public void Awake()
    {
        Cursor.visible = false;

        Cursor.SetCursor(aim, Vector2.zero, CursorMode.ForceSoftware);
    }
}
