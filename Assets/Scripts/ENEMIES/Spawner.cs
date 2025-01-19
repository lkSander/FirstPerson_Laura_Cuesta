using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    int nivelActual;
    int rondaActual;

    [SerializeField] TMP_Text nivel;
    [SerializeField] TMP_Text ronda;
    [SerializeField] TMP_Text time;
    float timer;

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
        timer = Time.deltaTime;
        nivel.SetText("Nvl  " + nivelActual);
        ronda.SetText("Ronda  " + rondaActual);
        time.SetText("Time  " + timer);

        if(nivelActual== numNiveles && timer>=0)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator SpawnEnemigos()
    {

        for(int i = 1; i<  numNiveles; i++)
        {
            nivelActual = i;
            for (int j = 0; j < rondasNiveles; j++)
            {
                rondaActual = j;
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
