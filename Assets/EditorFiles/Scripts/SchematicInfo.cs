using UnityEngine;

public class SchematicInfo : DefaultChildren
{
    public string Name;

    public uint ID;

    public void OnValidate()
    {
        transform.rotation = Quaternion.identity;
    }
}
