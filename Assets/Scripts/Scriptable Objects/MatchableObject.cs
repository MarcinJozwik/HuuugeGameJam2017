using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Body Part")]
public class MatchableObject : ScriptableObject {

    private string description;

    public Mesh MyModel;

    public string Description { get { return description; } }
}
