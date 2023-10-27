using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1);

        // Shuffle the balloons array
        ShuffleArray(balloons);

        for (int i = 0; i < balloons.Length; i++)
        {
            if (i < spawnPoints.Length)
            {
                Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Not enough spawn points for all balloons!");
            }
        }

        StartCoroutine(StartSpawning());
    }

    // Function to shuffle an array
    void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
