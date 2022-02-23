using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    public class SynapseSchematic : IConfigSection
    {
        [NonSerialized]
        internal bool reload = true;

        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> CustomAttributes { get; set; }

        public List<PrimitiveConfiguration> PrimitiveObjects { get; set; } = new List<PrimitiveConfiguration>();
        public List<LightSourceConfiguration> LightObjects { get; set; } = new List<LightSourceConfiguration>();
        public List<TargetConfiguration> TargetObjects { get; set; } = new List<TargetConfiguration>();
        public List<ItemConfiguration> ItemObjects { get; set; } = new List<ItemConfiguration>();
        public List<WorkStationConfiguration> WorkStationObjects { get; set; } = new List<WorkStationConfiguration>();
        public List<DoorConfiguration> DoorObjects { get; set; } = new List<DoorConfiguration>();

        public class PrimitiveConfiguration
        {
            public PrimitiveType PrimitiveType { get; set; }

            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public SerializedColor Color { get; set; }

            public Dictionary<string, string> CustomAttributes { get; set; }
        }

        public class LightSourceConfiguration
        {
            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public SerializedColor Color { get; set; }

            public float LightIntensity { get; set; }

            public float LightRange { get; set; }

            public bool LightShadows { get; set; }

            public Dictionary<string, string> CustomAttributes { get; set; }
        }

        public class TargetConfiguration
        {
            public TargetType TargetType { get; set; }

            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public Dictionary<string, string> CustomAttributes { get; set; }
        }

        public class ItemConfiguration
        {
            public ItemType ItemType { get; set; }

            public bool CanBePickedUp { get; set; }

            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public Dictionary<string, string> CustomAttributes { get; set; }
        }

        public class WorkStationConfiguration
        {
            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public bool UpdateEveryFrame { get; set; } = false;

            public Dictionary<string, string> CustomAttributes { get; set; }
        }

        public class DoorConfiguration
        {
            public SpawnableDoorType DoorType { get; set; }

            public SerializedVector3 Position { get; set; }

            public SerializedVector3 Rotation { get; set; }

            public SerializedVector3 Scale { get; set; }

            public bool Open { get; set; }

            public bool Locked { get; set; }

            public bool UpdateEveryFrame { get; set; } = false;

            public Dictionary<string, string> CustomAttributes { get; set; }
        }
    }

    public enum ItemType
    {
        None = -1,
        KeycardJanitor,
        KeycardScientist,
        KeycardResearchCoordinator,
        KeycardZoneManager,
        KeycardGuard,
        KeycardNTFOfficer,
        KeycardContainmentEngineer,
        KeycardNTFLieutenant,
        KeycardNTFCommander,
        KeycardFacilityManager,
        KeycardChaosInsurgency,
        KeycardO5,
        Radio,
        GunCOM15,
        Medkit,
        Flashlight,
        MicroHID,
        SCP500,
        SCP207,
        Ammo12gauge,
        GunE11SR,
        GunCrossvec,
        Ammo556x45,
        GunFSP9,
        GunLogicer,
        GrenadeHE,
        GrenadeFlash,
        Ammo44cal,
        Ammo762x39,
        Ammo9x19,
        GunCOM18,
        SCP018,
        SCP268,
        Adrenaline,
        Painkillers,
        Coin,
        ArmorLight,
        ArmorCombat,
        ArmorHeavy,
        GunRevolver,
        GunAK,
        GunShotgun,
        SCP330,
        SCP2176,
        SCP244a,
        SCP244b
    }


    public enum SpawnableDoorType
    {
        LCZ,
        HCZ,
        EZ
    }

    public enum TargetType
    {
        Sport,
        DBoy,
        Binary
    }

    [Serializable]
    public class SerializedVector3
    {
        public SerializedVector3(Vector3 vector)
        {
            X = vector.x;
            Y = vector.y;
            Z = vector.z;
        }

        public SerializedVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public SerializedVector3() { }

        public Vector3 Parse() => new Vector3(X, Y, Z);

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static implicit operator Vector3(SerializedVector3 vector) => vector.Parse();
        public static implicit operator SerializedVector3(Vector3 vector) => new SerializedVector3(vector);
    }

    [Serializable]
    public class SerializedColor
    {
        public SerializedColor() { }

        public SerializedColor(Color32 color)
        {
            R = color.r / 255f;
            G = color.g / 255f;
            B = color.b / 255f;
            A = color.a / 255f;
        }
        public SerializedColor(Color color)
        {
            R = color.r;
            G = color.g;
            B = color.b;
            A = color.a;
        }
        public SerializedColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public Color Parse() => new Color(R, G, B, A);

        public static implicit operator Color(SerializedColor color) => color.Parse();
        public static implicit operator SerializedColor(Color color) => new SerializedColor(color);
        public static implicit operator Color32(SerializedColor color) => (Color32)color.Parse();
        public static implicit operator SerializedColor(Color32 color) => new SerializedColor(color);

    }
}
