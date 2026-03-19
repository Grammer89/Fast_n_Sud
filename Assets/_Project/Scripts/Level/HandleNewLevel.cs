using UnityEngine;

public class HandleNewLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility.PLAYERTAG))
        {
            GameObject nextLevel = LevelManager.Instance.GetLevel();
            SpawnNextLevel(nextLevel);
        }
    }

    public void SpawnNextLevel(GameObject nextLevelPrefab)
    {
        GameObject ObjectSpawn = GameObject.FindWithTag(Utility.SENSORSPAWNINGLEVELTAG);

        GameObject nextLevel = Instantiate(nextLevelPrefab);
        nextLevel.transform.position = ObjectSpawn.transform.position;

    }
}
