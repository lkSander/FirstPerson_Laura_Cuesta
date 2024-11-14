using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //.position porque busca un vector3
        //quaternion.identity es 0,0,0
        StartCoroutine(SpawnEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemigos()
    {
        while(true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);

            yield return new WaitForSeconds(3);
        }
        

    }
}
