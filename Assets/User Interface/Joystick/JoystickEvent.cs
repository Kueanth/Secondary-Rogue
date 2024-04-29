using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Progress.Instance.isJoystick = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Progress.Instance.isJoystick = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Progress.Instance.isJoystick = true;
    }
}
