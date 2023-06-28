using System.Collections.Generic;
using UnityEngine;

public class ThindsCollector : MonoBehaviour
{
    private Queue<Thing> _things = new Queue<Thing>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thing thing))
        {
            thing.transform.parent = transform;
            _things.Enqueue(thing);
            thing.Connect();
        }
    }

    public bool TryGetThing(out Thing thing)
    {
        if (_things.Count != 0)
        {
            thing = _things.Dequeue();
        }
        else
        {
            thing = null;
            return false;
        }

        return true;
    }
}
