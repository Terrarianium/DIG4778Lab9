using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject meteorPrefab; // Prefab of the meteor to spawn.
    private NormalMeteorBuilder normalMeteorBuilder = new NormalMeteorBuilder(); // Builder for normal meteors.
    private SmallMeteorBuilder smallMeteorBuilder = new SmallMeteorBuilder(); // Builder for big meteors.
    private FastMeteorBuilder fastMeteorBuilder = new FastMeteorBuilder(); // Builder for fast meteors.

    // Start spawning enemies when game beings.
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }


    // Coroutine to spawn enemies at random positions. Enemies come in three different types.
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int direction = Random.Range(0, 2) == 0 ? 1 : -1; // Randomly choose direction.
            int yPosition = 1 + (3 * Random.Range(0, 3)); // Randomly choose y position.
            int meteorToSpawn = Random.Range(0, 3); // Randomly choose type of meteor to spawn.
            switch (meteorToSpawn)
            {
                case 0:
                    smallMeteorBuilder.Build(meteorPrefab, new Vector3(direction * 20, yPosition, 0), Quaternion.identity, -direction); // Build and spawn a big meteor.
                    break;
                case 1:
                    normalMeteorBuilder.Build(meteorPrefab, new Vector3(direction * 20, yPosition, 0), Quaternion.identity, -direction); // Build and spawn a normal meteor.
                    break;
                case 2:
                    fastMeteorBuilder.Build(meteorPrefab, new Vector3(direction * 20, yPosition, 0), Quaternion.identity, -direction); // Build and spawn a fast meteor.
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(.5f); // Cooldown between spawns.
        }
    }
}
