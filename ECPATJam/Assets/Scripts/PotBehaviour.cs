using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    public List<string> materials = new List<string>();

    public void AddMaterial(string materialname)
    {
        materials.Add(materialname);
    }

    public void CookMaterial()
    {
        
    }
}
