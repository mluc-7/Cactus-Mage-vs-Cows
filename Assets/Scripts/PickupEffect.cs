using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupEffect : ScriptableObject //is abstract so it can not be instantiated but allows us to define a common behaviour
{
    //apply effect to the gameObject
    public abstract void Apply(GameObject target);
}
