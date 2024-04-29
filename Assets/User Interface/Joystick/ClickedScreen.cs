using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedScreen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        string name = eventData.pointerCurrentRaycast.gameObject.name;

        if (name == "Fixed Joystick" || name == "Handle")
            Progress.Instance.isShoot = false;
        else
        {
            Progress.Instance.isShoot = true;
            Progress.Instance.positionClick = eventData.position;
        }

        Debug.Log(Progress.Instance.isShoot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Progress.Instance.positionClick += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Progress.Instance.isShoot = false;
        Debug.Log(Progress.Instance.isShoot);
    }
}
