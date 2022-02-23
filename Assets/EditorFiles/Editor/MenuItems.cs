using UnityEditor;
using UnityEngine;


public class MenuItems
{
    [MenuItem("Component/DeleteMissingComponents")]
    private static void SelectMissing(MenuCommand command)
    {
        var deepSelection = EditorUtility.CollectDeepHierarchy(Selection.gameObjects);
        int compCount = 0;
        int goCount = 0;
        foreach (var o in deepSelection)
        {
            if (o is GameObject go)
            {
                int count = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(go);
                if (count > 0)
                {
                    // Edit: use undo record object, since undo destroy wont work with missing
                    Undo.RegisterCompleteObjectUndo(go, "Remove missing scripts");
                    GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
                    compCount += count;
                    goCount++;
                }
            }
        }
        Debug.Log($"Found and removed {compCount} missing scripts from {goCount} GameObjects");
    }
}

[CustomEditor(typeof(Primitive))]
public class PrimitiveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Please don't change the Primitive Type", MessageType.Info);
    }
}

[CustomEditor(typeof(Door))]
public class DoorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Please don't change the DoorType.\nOpen and Locked will not be displayed in the editor yet", MessageType.Info);
    }
}

[CustomEditor(typeof(Target))]
public class TargetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Please don't change anything here", MessageType.Info);
    }
}

[CustomEditor(typeof(LightObject))]
public class LightEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Please don't change Lightcomp", MessageType.Info);
    }
}

[CustomEditor(typeof(SchematicInfo))]
public class SchematicEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Here can you change the Name and ID of the Schematic\nPlease remeber that every Schematic needs a different ID since they are used to spawn them", MessageType.Info);
    }
}

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Please don't change ItemType except this is a KeyCard and you want to change the KeyCard Type", MessageType.Info);
    }
}
