using Config;
using System.IO;
using UnityEngine;
using Syml;

public class Generate : MonoBehaviour
{
    void Start()
    {
        var schematicGameobjects = GameObject.FindObjectsOfType<SchematicInfo>();

        foreach(var info in schematicGameobjects)
        {
            var schematic = new SchematicConfiguration
            {
                Name = info.Name,
                Id = info.ID,
                CustomAttributes = info.GetAttributes(),
            };
            Debug.Log("Found Schematic " + info.Name);

            foreach(var objectinfo in info.GetComponentsInChildren<ObjectInfo>())
            {
                var child = objectinfo.transform;
                var pos = info.transform.InverseTransformPoint(child.position);
                var rot = info.transform.TransformDirection(child.rotation.eulerAngles);
                var scale = new Vector3(info.transform.localScale.x * child.lossyScale.x, info.transform.localScale.y * child.lossyScale.y, info.transform.localScale.z * child.lossyScale.z);

                switch (objectinfo.Type)
                {
                    case ObjectType.Door:
                        var door = child.GetComponent<Door>();
                        schematic.Doors.Add(new SchematicConfiguration.DoorConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            DoorType = door.DoorType,
                            Locked = door.Locked,
                            Open = door.Open,
                            UpdateEveryFrame = door.UpdateEveryFrame,
                            CustomAttributes = door.GetAttributes(),
                        });

                        break;

                    case ObjectType.Target:
                        var target = child.GetComponent<Target>();
                        schematic.Targets.Add(new SchematicConfiguration.TargetConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            TargetType = target.TargetType,
                            CustomAttributes = target.GetAttributes(),
                        });
                        break;

                    case ObjectType.Workstation:
                        var work = child.GetComponent<WorkStation>();
                        schematic.WorkStations.Add(new SchematicConfiguration.SimpleUpdateConfig
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            UpdateEveryFrame = work.UpdateEveryFrame,
                            CustomAttributes = work.GetAttributes(),
                        });
                        break;

                    case ObjectType.Item:
                        var item = child.GetComponent<Item>();
                        schematic.Items.Add(new SchematicConfiguration.ItemConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CanBePickedUp = item.CanBePickedUp,
                            ItemType = item.itemType,
                            CustomAttributes = item.GetAttributes(),
                            Attachments = item.Attachments,
                            Durabillity = item.Durabillity,
                            Physics = item.Physics,
                        });
                        break;

                    case ObjectType.LightSource:
                        var light = child.GetComponent<LightObject>();
                        schematic.Lights.Add(new SchematicConfiguration.LightSourceConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            Color = light.color,
                            LightIntensity = light.intensity,
                            LightRange = light.range,
                            LightShadows = light.shadow,
                            CustomAttributes = light.GetAttributes(),
                        });
                        break;

                    case ObjectType.Primitive:
                        var prim = child.GetComponent<Primitive>();
                        schematic.Primitives.Add(new SchematicConfiguration.PrimitiveConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            Color = prim.color,
                            PrimitiveType = prim.PrimitiveType,
                            CustomAttributes = prim.GetAttributes(),
                            Physics = prim.Physics,
                        });
                        break;

                    case ObjectType.Custom:
                        var custom = child.GetComponent<CustomObject>();
                        schematic.CustomObjects.Add(new SchematicConfiguration.CustomObjectConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            ID = custom.ID,
                            CustomAttributes = custom.GetAttributes(),
                        });
                        break;

                    case ObjectType.Locker:
                        var locker = child.GetComponent<Locker>();
                        schematic.Lockers.Add(new SchematicConfiguration.LockerConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CustomAttributes = locker.GetAttributes(),
                            Chambers = locker.Chambers,
                            DeleteDefaultItems = locker.DeleteDefaultItems,
                            LockerType = locker.LockerType,
                            UpdateEveryFrame = locker.UpdateEveryFrame,
                        });
                        break;

                    case ObjectType.Dummy:
                        var dummy = child.GetComponent<Dummy>();
                        schematic.Dummies.Add(new SchematicConfiguration.DummyConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CustomAttributes = dummy.GetAttributes(),
                            Badge = dummy.Badge,
                            BadgeColor = dummy.BadgeColor,
                            HeldItem = dummy.HeldItem,
                            Name = dummy.Name,
                            Role = dummy.Role,
                        });
                        break;

                    case ObjectType.Ragdoll:
                        var rag = child.GetComponent<Ragdoll>();
                        schematic.Ragdolls.Add(new SchematicConfiguration.RagdollConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CustomAttributes = rag.GetAttributes(),
                            DamageType = rag.DamageType,
                            Nick = rag.Nick,
                            RoleType = rag.RoleType,
                        });
                        break;

                    case ObjectType.Generator:
                        var gen = child.GetComponent<Generator>();
                        schematic.Generators.Add(new SchematicConfiguration.SimpleUpdateConfig
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CustomAttributes = gen.GetAttributes(),
                            UpdateEveryFrame = gen.UpdateEveryFrame,
                        });
                        break;
                }
            }

            var path = Path.Combine(Application.dataPath, "Schematics");
            var file = Path.Combine(path, schematic.Name + ".syml");
            var syml = new SymlDocument();
            syml.Set(schematic.Name, schematic);
            File.WriteAllText(file, syml.Dump(), System.Text.Encoding.UTF8);
        }
    }
}
