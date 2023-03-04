using Config;
using System.Collections.Generic;
using static Config.SchematicConfiguration.LockerConfiguration;

public class Locker : DefaultChildren
{
    public LockerType LockerType = 0;

    public List<LockerChamber> Chambers = new List<LockerChamber>();

    public bool DeleteDefaultItems = false;

    public bool UpdateEveryFrame = false;
}
