using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : UserInput, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.IsPointerMoving())
        {
            Moving?.Invoke(new Vector3(eventData.delta.x / 15, 0, 0));
        }
    }
}
