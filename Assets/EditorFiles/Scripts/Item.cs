using Config;
using UnityEngine;

public class Item : DefaultChildren
{
    public ItemType itemType = ItemType.None;

    public bool CanBePickedUp = false;

    public bool Physics = true;

    public float Durabillity = 0f;

    public uint Attachments = 0;
}
