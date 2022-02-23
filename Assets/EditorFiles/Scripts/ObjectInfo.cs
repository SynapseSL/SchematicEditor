using UnityEngine;

public enum ObjectType
{
    Shematic,
    Primitive,
    LightSource,
    Target,
    Door,
    Workstation,
    Item
}

public class ObjectInfo : MonoBehaviour
{
    public ObjectType Type;
}
