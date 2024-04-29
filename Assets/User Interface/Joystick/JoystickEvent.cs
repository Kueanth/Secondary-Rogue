using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        string name = eventData.pointerCurrentRaycast.gameObject.name;

        if (name == "Fixed Joystick" || name == "Handle")
            Progress.Instance.isJoystick = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        string name = eventData.pointerCurrentRaycast.gameObject.name;

        if (name == "Fixed Joystick" || name == "Handle")
            Progress.Instance.isJoystick = false;
    }
}
