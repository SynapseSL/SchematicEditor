using UnityEngine;

public enum ObjectType
{
    Shematic,
    Primitive,
    LightSource,
    Target,
    Door,
    Workstation,
    Item,
    Ragdoll,
    Dummy,
    Custom,
    Locker,
    Generator
}

public class ObjectInfo : MonoBehaviour
{
    public ObjectType Type;
}
