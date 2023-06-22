using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : UserInput, IDragHandler
{
    private float _coefficientTouchMoving = 1 / 15;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.IsPointerMoving())
        {
            Moving?.Invoke(new Vector3(eventData.delta.x * _coefficientTouchMoving, 0, 0));
        }
    }
}
