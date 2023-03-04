using System;
using System.Collections.Generic;
using UnityEngine;
using Syml;

namespace Config
{
    [Serializable]
    public class SchematicConfiguration : IDocumentSection
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public List<string> CustomAttributes { get; set; }

        public List<PrimitiveConfiguration> Primitives { get; set; } = new List<PrimitiveConfiguration>();
        public List<LightSourceConfiguration> Lights { get; set; } = new List<LightSourceConfiguration>();
        public List<TargetConfiguration> Targets { get; set; } = new List<TargetConfiguration>();
        public List<ItemConfiguration> Items { get; set; } = new List<ItemConfiguration>();
        public List<SimpleUpdateConfig> WorkStations { get; set; } = new List<SimpleUpdateConfig>();
        public List<DoorConfiguration> Doors { get; set; } = new List<DoorConfiguration>();
        public List<CustomObjectConfiguration> CustomObjects { get; set; } = new List<CustomObjectConfiguration>();
        public List<RagdollConfiguration> Ragdolls { get; set; } = new List<RagdollConfiguration>();
        public List<DummyConfiguration> Dummies { get; set; } = new List<DummyConfiguration>();
        public List<SimpleUpdateConfig> Generators { get; set; } = new List<SimpleUpdateConfig>();
        public List<LockerConfiguration> Lockers { get; set; } = new List<LockerConfiguration>();
        public List<OldGrenadeConfiguration> OldGrenades { get; set; } = new List<OldGrenadeConfiguration>();


        public abstract class DefaultConfig
        {
            public SerializedVector3 Position { get; set; } = Vector3.zero;

            public SerializedVector3 Rotation { get; set; } = Vector3.zero;

            public SerializedVector3 Scale { get; set; } = Vector3.one;

            public List<string> CustomAttributes { get; set; } = new List<string>();
        }

        public class SimpleUpdateConfig : DefaultConfig
        {
            public bool UpdateEveryFrame { get; set; } = false;
        }

        public class OldGrenadeConfiguration : SimpleUpdateConfig
        {
            public bool IsFlash { get; set; }
        }

        public class PrimitiveConfiguration : DefaultConfig
        {
            public PrimitiveType PrimitiveType { get; set; }

            public bool Physics { get; set; }

            public SerializedColor Color { get; set; }
        }

        public class LightSourceConfiguration : DefaultConfig
        {
            public SerializedColor Color { get; set; }

            public float LightIntensity { get; set; }

            public float LightRange { get; set; }

            public bool LightShadows { get; set; }
        }

        public class TargetConfiguration : DefaultConfig
        {
            public TargetType TargetType { get; set; }
        }

        public class ItemConfiguration : DefaultConfig
        {
            public ItemType ItemType { get; set; }

            public bool CanBePickedUp { get; set; } = true;

            public bool Physics { get; set; } = true;

            public float Durabillity { get; set; } = 0;

            public uint Attachments { get; set; } = 0;
        }

        public class DoorConfiguration : SimpleUpdateConfig
        {
            public SpawnableDoorType DoorType { get; set; }

            public bool Open { get; set; }

            public bool Locked { get; set; }

            public float Health { get; set; } = -1f;

            public bool UnDestroyable { get; set; } = false;
        }

        public class CustomObjectConfiguration : DefaultConfig
        {
            public int ID { get; set; }
        }

        public class RagdollConfiguration : DefaultConfig
        {
            public string Nick { get; set; }

            public RoleType RoleType { get; set; }

            public DamageType DamageType { get; set; }
        }

        public class DummyConfiguration : DefaultConfig
        {
            public RoleType Role { get; set; }

            public ItemType HeldItem { get; set; }

            public string Name { get; set; }

            public string Badge { get; set; }

            public string BadgeColor { get; set; }
        }

        public class LockerConfiguration : SimpleUpdateConfig
        {
            public LockerType LockerType { get; set; }

            public List<LockerChamber> Chambers { get; set; } = new List<LockerChamber>();

            public bool DeleteDefaultItems { get; set; }

            public class LockerChamber
            {
                public List<ItemType> Items { get; set; } = new List<ItemType>();
            }
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
}

public enum LockerType
{
    StandardLocker,
    LargeGunLocker,
    RifleRackLocker,
    ScpPedestal,
    MedkitWallCabinet,
    AdrenalineWallCabinet
}

public enum RoleType : sbyte
{
    Scp173,
    ClassD,
    Spectator,
    Scp106,
    NtfSpecialist,
    Scp049,
    Scientist,
    Scp079,
    ChaosConscript,
    Scp096,
    Scp0492,
    NtfSergeant,
    NtfCaptain,
    NtfPrivate,
    Tutorial,
    FacilityGuard,
    Scp93953,
    Scp93989,
    ChaosRifleman,
    ChaosRepressor,
    ChaosMarauder
}

public enum DamageType
{
    Recontained,
    Warhead,
    Scp049,
    Unknown,
    Asphyxiated,
    Bleeding,
    Falldown,
    PocketDecay,
    Decontamination,
    Poisoned,
    Scp207,
    SeveredHands,
    MicroHID,
    Tesla,
    Explosion,
    Scp096,
    Scp173,
    Scp939,
    Zombie,
    BulletWounds,
    Crushed,
    UsedAs106Bait,
    FriendlyFireDetector,
    Hypothermia,

    Universal,
    CustomReason,
    Disruptor,
    Firearm,
    MicroHid,
    Recontainment,
    Scp018,
    Scp,
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
