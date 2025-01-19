using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Video;
public class ArmaFuego : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
   [SerializeField] LayerMask enemy;
    Animator animator;
    [SerializeField] ArmaSO datos;
   

    [SerializeField] bool estaAtacando = false;

    [SerializeField] Transform puntoAtaque;


    [SerializeField] float danioAtaque;


    // Start is called before the first frame update
    void Start()
    {
        danioAtaque = 20;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Atacar();
    }

    private void Atacar()
    {
       // Debug.Log("fase");
        if (Input.GetMouseButton(0) && !estaAtacando)
        {


            estaAtacando = true;
            animator.SetTrigger("Atacar");
            DetectarImpacto();
          //  Debug.Log("fase");
        }
    }
    private void FinAtaque()
    {

        estaAtacando = false;
      //  Debug.Log("fase");
    }



    private void DetectarImpacto()
    {
        system.Play();
        //1.attack point referencia
        //2. recrear variable responsable al radio
        //3. variable que es dañable (layer)
        Collider[] collDetectados = Physics.OverlapSphere(puntoAtaque.position, datos.distanciaAtaque, enemy);
        if (collDetectados.Length > 0)
        {
            //aplicar daño a todos los colliders
            for (int i = 0; i < collDetectados.Length; i++)
            {

                collDetectados[i].GetComponent<PedroZombie>().RecibirDanho(danioAtaque);


            }
            //puedoDaniar = true;
        }
    }


    private void OnDrawGizmosSelected()
    {
        //Ver el radio del ataque de la espada
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoAtaque.position, datos.distanciaAtaque);
    }

}
