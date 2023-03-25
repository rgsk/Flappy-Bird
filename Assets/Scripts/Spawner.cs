using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), time: spawnRate, repeatRate: spawnRate);
    }
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn() {
        GameObject pipes = Instantiate(prefab, position: transform.position, rotation: Quaternion.identity); // Quaternion.identity means no rotation
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
