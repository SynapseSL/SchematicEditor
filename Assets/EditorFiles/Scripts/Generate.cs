using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using System.IO;

public class Generate : MonoBehaviour
{
    void Start()
    {
        var schematicGameobjects = GameObject.FindObjectsOfType<SchematicInfo>();

        foreach(var info in schematicGameobjects)
        {
            var schematic = new SynapseSchematic
            {
                Name = info.Name,
                ID = info.ID,
            };
            Debug.Log("Found Schematic " + info.Name);

            for (int i = 0; i < info.transform.childCount; i++)
            {
                var child = info.transform.GetChild(i);
                var objectinfo = child.GetComponent<ObjectInfo>();

                switch (objectinfo.Type)
                {
                    case ObjectType.Door:
                        var door = child.GetComponent<Door>();
                        schematic.DoorObjects.Add(new SynapseSchematic.DoorConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            DoorType = door.DoorType,
                            Locked = door.Locked,
                            Open = door.Open,
                            UpdateEveryFrame = door.UpdateEveryFrame,
                        });
                        
                        break;

                    case ObjectType.Target:
                        var target = child.GetComponent<Target>();
                        schematic.TargetObjects.Add(new SynapseSchematic.TargetConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            TargetType = target.TargetType
                        });
                        break;

                    case ObjectType.Workstation:
                        var work = child.GetComponent<WorkStation>();
                        schematic.WorkStationObjects.Add(new SynapseSchematic.WorkStationConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            UpdateEveryFrame = work.UpdateEveryFrame
                        });
                        break;

                    case ObjectType.Item:
                        var item = child.GetComponent<Item>();
                        schematic.ItemObjects.Add(new SynapseSchematic.ItemConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            CanBePickedUp = item.CanBePickedUp,
                            ItemType = item.itemType
                        });
                        break;

                    case ObjectType.LightSource:
                        var light = child.GetComponent<LightObject>();
                        schematic.LightObjects.Add(new SynapseSchematic.LightSourceConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            Color = light.color,
                            LightIntensity = light.intensity,
                            LightRange = light.range,
                            LightShadows = light.shadow
                        });
                        break;

                    case ObjectType.Primitive:
                        var prim = child.GetComponent<Primitive>();
                        schematic.PrimitiveObjects.Add(new SynapseSchematic.PrimitiveConfiguration
                        {
                            Position = child.transform.localPosition,
                            Rotation = child.transform.localRotation.eulerAngles,
                            Scale = child.transform.localScale,
                            Color = prim.color,
                            PrimitiveType = prim.PrimitiveType
                        });
                        break;
                }
            }

            var path = Path.Combine(Application.dataPath, "Schematics");
            var file = Path.Combine(path, schematic.Name + ".syml");
            var syml = new SYML(file);
            var section = new ConfigSection { Section = schematic.Name };
            section.Import(schematic);
            syml.Sections.Add(schematic.Name, section);
            syml.Store();
        }
    }
}
