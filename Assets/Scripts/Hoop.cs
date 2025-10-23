using UnityEngine;

public class Hoop : MonoBehaviour
{
    public GameObject hoopPrefab;
    private GameObject spawnedHoop;

    // Will spawn within these boundaries can tweak in inspector
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        SpawnHoop();
    }

    public void SpawnHoop()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        if (spawnedHoop != null)
            Destroy(spawnedHoop);

        spawnedHoop = Instantiate(hoopPrefab, spawnPos, Quaternion.identity);
    }
}
