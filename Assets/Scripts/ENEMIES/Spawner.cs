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
        Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
