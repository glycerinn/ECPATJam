using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{
    public GameObject materialPrefab;
    public MaterialSO materialData;
    public Transform spawnPoint;

    void OnMouseDown()
    {
        SpawnMaterial();
    }

    void SpawnMaterial()
    {
        GameObject obj = Instantiate(materialPrefab, spawnPoint.position, Quaternion.identity);

        MaterialBehaviour mat = obj.GetComponent<MaterialBehaviour>();

        mat.StartDragging();

        if(mat != null)
        {
            mat.SetMaterial(materialData);
        }
    }
}
