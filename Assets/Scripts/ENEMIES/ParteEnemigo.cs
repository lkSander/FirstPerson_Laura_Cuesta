using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{

    [SerializeField] private PedroZombie mainScript;
    [SerializeField] private float multiplicadorDanio;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibirDanio(float danio)
    {

        //mainScript.Vidas -= multiplicadorDanio;
        //if(mainScript.Vidas<=0)
        //{

        //    mainScript.Morir();
        //}


    }
    public void Explotar(float fuerzaImpulso, Vector3 puntoImpacto, float radioExplosion, float pModifier)
    {

    }
}
