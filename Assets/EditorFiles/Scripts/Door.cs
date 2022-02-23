using Config;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpawnableDoorType DoorType = SpawnableDoorType.LCZ;

    public bool Open = false;

    public bool Locked = false;

    public bool UpdateEveryFrame = false;
}
