using UnityEngine;

public class SchematicInfo : MonoBehaviour
{
    public string Name;

    public int ID;

    public void OnValidate()
    {
        transform.rotation = Quaternion.identity;
    }
}
