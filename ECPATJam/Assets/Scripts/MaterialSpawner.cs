using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{
    public GameObject materialPrefab;
    public MaterialSO materialData;
    public Transform spawnPoint;
    private AudioManager audioManager;
    
    public void Awake()
    {
        GameObject audioObj = GameObject.FindGameObjectWithTag("AudioManager");

        if (audioObj != null)
        {
            audioManager = audioObj.GetComponent<AudioManager>();
            Debug.Log("found");
        }
        else
        {
            Debug.LogError("AudioManager not found in scene!");
        }
            
    } 

    void OnMouseDown()
    {
        audioManager.playGrab();
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
