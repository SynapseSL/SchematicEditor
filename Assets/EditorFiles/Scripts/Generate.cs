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
                        schematic.DoorObjects.Add(new SynapseSchematic.DoorConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
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
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            TargetType = target.TargetType
                        });
                        break;

                    case ObjectType.Workstation:
                        var work = child.GetComponent<WorkStation>();
                        schematic.WorkStationObjects.Add(new SynapseSchematic.WorkStationConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            UpdateEveryFrame = work.UpdateEveryFrame
                        });
                        break;

                    case ObjectType.Item:
                        var item = child.GetComponent<Item>();
                        schematic.ItemObjects.Add(new SynapseSchematic.ItemConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
                            CanBePickedUp = item.CanBePickedUp,
                            ItemType = item.itemType
                        });
                        break;

                    case ObjectType.LightSource:
                        var light = child.GetComponent<LightObject>();
                        schematic.LightObjects.Add(new SynapseSchematic.LightSourceConfiguration
                        {
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
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
                            Position = pos,
                            Rotation = rot,
                            Scale = scale,
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
