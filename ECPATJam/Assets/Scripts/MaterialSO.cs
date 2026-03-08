using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Materials")]
public class MaterialSO : ScriptableObject
{
    public new string name;
    public Vector3 MaterialStartPos;
    public Sprite MaterialSprite;
}
