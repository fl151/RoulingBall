using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : UserInput, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        float xDelta = eventData.delta.x;

        if (xDelta != 0)
        {
            Moving.Invoke(new Vector3(xDelta, 0, 0));
        }
    }
}
