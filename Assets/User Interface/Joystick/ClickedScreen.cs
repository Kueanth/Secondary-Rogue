using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedScreen : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string name = eventData.pointerCurrentRaycast.gameObject.name;

        if (name == "Fixed Joystick" || name == "Handle")
            Progress.Instance.isJoystick = true;
        else
            Progress.Instance.isJoystick = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Progress.Instance.isJoystick = false;
    }
}
