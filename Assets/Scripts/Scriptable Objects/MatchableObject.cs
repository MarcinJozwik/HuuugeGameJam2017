using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Body Part")]
public class MatchableObject : ScriptableObject
{
    public Mesh MyModel = null;
    public Material MyMaterial = null;
    public string Name = "";
    public Texture2D MyTexture;
}
