using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] float distancia;
    Camera cam;
    Transform interactuableActual;
    
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Deteccion();
    }
    void Deteccion()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distancia))
        {
            if(hit.transform.TryGetComponent(out Barril script))
            {

                interactuableActual = script.transform;

                interactuableActual.GetComponent<Outline>().enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    script.AbrirCaja();
                }
                
            }


            if (hit.transform.TryGetComponent(out Paja pajaScript))
            {

                interactuableActual = pajaScript.transform;

                interactuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("Oña");
                    pajaScript.Busqueda();
                }

            }

        }
        else if(interactuableActual != null)
        {

            interactuableActual.GetComponent<Outline>().enabled=false;
            interactuableActual=null;
        }
    }
}
