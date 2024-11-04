using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PedroZombie : MonoBehaviour
{
    [SerializeField] Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDa�able;

    private bool puedoDaniar = true;

    private NavMeshAgent agent;
    private FirstPerson player;
    Animator animator;

    [SerializeField] private float danioEnemigo;

    private bool ventanaAbierta;
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        player=GameObject.FindObjectOfType<FirstPerson>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();

        if(ventanaAbierta && puedoDaniar)
        {
            DetectarImpacto();
        }
        
    }

    private void DetectarImpacto()
    {

        //1.attack point referencia
        //2. recrear variable responsable al radio
        //3. variable que es da�able (layer)
        Collider[] collDetectados= Physics.OverlapSphere(puntoAtaque.position, radioAtaque, queEsDa�able);
        if (collDetectados.Length > 0 )
        {
            //aplicar da�o a todos los colliders
            for(int i = 0; i < collDetectados.Length; i++)
            {

                collDetectados[i].GetComponent<FirstPerson>().RecibirDanio(danioEnemigo);


            }
            puedoDaniar= false;
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.gameObject.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true; //el eneimgo se queda quieto si loe empujas a esa distancia
            animator.SetBool("Attacking", true);
            puedoDaniar = true;


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void FinAtaque()
    {


        agent.isStopped= false;
        animator.SetBool("Attacking", false);
    }

    private void AbrirVentana()
    {
        ventanaAbierta = true;
    }
    private void CerrarVentana()
    {
        ventanaAbierta=false;   
    }
}
