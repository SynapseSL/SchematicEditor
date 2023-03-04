using System.Collections.Generic;
using UnityEngine;

public class DefaultChildren : MonoBehaviour
{
    public List<string> CustomAttributes = null;

    public List<DefaultCustomAttributes> DefaultCustomAttributes = null;

    public List<string> GetAttributes()
    {
        if(CustomAttributes == null && DefaultCustomAttributes == null) return null;

        var list = CustomAttributes;
        if(list == null) list = new List<string>();

        foreach (var attr in DefaultCustomAttributes)
            list.Add(attr.ToString());

        return list;
    }
}

public enum DefaultCustomAttributes
{
    Breakable
}

