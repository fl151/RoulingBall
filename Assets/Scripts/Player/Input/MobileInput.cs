using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : UserInput, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        float xDelta = eventData.delta.x;

        if (xDelta != 0)
        {
            if(xDelta > 0)
            {
                Moving?.Invoke(Vector3.right);
            }
            else
            {
                Moving?.Invoke(Vector3.left);
            }
        }
    }
}
