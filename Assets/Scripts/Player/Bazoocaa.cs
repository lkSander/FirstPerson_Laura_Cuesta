using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoocaa : MonoBehaviour
{

    [SerializeField] GameObject granadaPrefab;
    [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(granadaPrefab, spawnPoint.position, transform.rotation);

           
        }


    }
}
