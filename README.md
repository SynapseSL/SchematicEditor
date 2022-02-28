# SchematicEditor
This is an editor for the creation of custom object in the Game SCP: Secret Laboratory.

# Requirements
* [Unity 2019.4.16f1](https://unity3d.com/de/get-unity/download/archive)
* [Synapse](https://github.com/SynapseSL/Synapse) 2.9.0 or higher

# Tutorial
For using this Editor you should have some basic Unity knowledge about the Unity interface.
You can use all Prefabs you can access inside the Asset directory(open by default) and its sub directories. However don't modify anything inside the `EditorFiles` directory since it contains all the scripts, mesh and textures needed for the Editor in the backgorund.

## How to create a Schematic
1. Download this repo and open it with unity [Unity 2019.4.16f1](https://unity3d.com/de/get-unity/download/archive)
2. Open the Editor scene
3. Place the Schematic Prefab in the scene
4. Set a Name and ID in its SchematicInfo Component
5. Spawn a prefab and add it as child of the Schematic Object

The Editor also supports to add a object as child of another child. This means you can create your own prefab out of the availabe prefabs and simply add the entire object as child.
