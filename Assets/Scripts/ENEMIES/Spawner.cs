using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private int numNiveles;
    [SerializeField] private int rondasNiveles;
    [SerializeField] private float esperaEntreSpawns;
    [SerializeField] private float esperaEntreRondas;
    [SerializeField] private float spawnPorRonda;
    [SerializeField] private float esperaEntreNiveles;

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

        for(int i = 0; i<  numNiveles; i++)
        {

            for (int j = 0; j < rondasNiveles; j++)
            {

                for(float k = 0; k < spawnPorRonda; k++)
                {
                    
                    
                       Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);

                        yield return new WaitForSeconds(esperaEntreSpawns);
                    

                }
                yield return new WaitForSeconds(esperaEntreRondas); 
            }

            yield return new WaitForSeconds(esperaEntreNiveles);
             


        }

    }
}
