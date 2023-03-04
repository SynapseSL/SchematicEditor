using Config;
using System.Collections.Generic;
using UnityEngine;

public class Door : DefaultChildren
{
    public SpawnableDoorType DoorType = SpawnableDoorType.LCZ;

    public bool Open = false;

    public bool Locked = false;

    public bool UpdateEveryFrame = false;
}
