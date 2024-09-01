using UnityEngine;
using UnityEditor;

public class CreatePhysicMaterial
{
    [MenuItem("Assets/Create/Physic Material")]
    public static void CreateYourPhysicMaterial()
    {
        PhysicMaterial material = new PhysicMaterial();
        AssetDatabase.CreateAsset(material, "Assets/NewPhysicMaterial.physicMaterial");
        AssetDatabase.SaveAssets();
    }
}
