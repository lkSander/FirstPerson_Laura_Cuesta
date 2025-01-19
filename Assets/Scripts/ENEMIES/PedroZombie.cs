using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PedroZombie : MonoBehaviour
{
    [SerializeField] Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDaniable;
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] GameObject monedasOroPrefab;

    private bool puedoDaniar = true;

    [SerializeField] private float vida;

    private NavMeshAgent agent;
    private FirstPerson player;
    Animator animator;

    [SerializeField] private float danioEnemigo;

    private bool ventanaAbierta;

    Rigidbody[] huesos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        animator = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();

        //CambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            Perseguir();
        }


        if (ventanaAbierta && puedoDaniar)
        {
            DetectarImpacto();
        }

    }

    private void DetectarImpacto()
    {

        //1.attack point referencia
        //2. recrear variable responsable al radio
        //3. variable que es dañable (layer)
        Collider[] collDetectados = Physics.OverlapSphere(puntoAtaque.position, radioAtaque, queEsDaniable);
        if (collDetectados.Length > 0)
        {
            //aplicar daño a todos los colliders
            for (int i = 0; i < collDetectados.Length; i++)
            {

                collDetectados[i].GetComponent<FirstPerson>().RecibirDanio(danioEnemigo);
                Debug.Log("nya");

            }
            puedoDaniar = false;
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.gameObject.transform.position);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true; //el eneimgo se queda quieto si loe empujas a esa distancia
            animator.SetBool("Attacking", true);
            puedoDaniar = true;

            EnfocarObjetivo();
        }
    }


    private void EnfocarObjetivo()
    {
        Vector3 direccionAObjetivo = (player.transform.position - transform.position).normalized;

        direccionAObjetivo.y = 0;

       Quaternion rotacionAObjetivo= Quaternion.LookRotation(direccionAObjetivo);

        transform.rotation= rotacionAObjetivo;

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
    //private void CambiarEstadoHuesos(bool estado)
    //{
    //    for (int i = 0; i < huesos.Length; i++)
    //    {
    //       huesos[i].isKinematic = estado;

    //    }
        
    //}
    public void RecibirDanho(float danhioRecibido)
    {
        Debug.Log("Dadeujas");
        vida -= danhioRecibido;
        if (vida <= 0)
        {
           
            // CambiarEstadoHuesos(false);
            monedasOroPrefab.transform.position = this.transform.position;
            Instantiate(monedasOroPrefab);
            //monedasOroPrefab.transform.position = this.transform.position;

           Destroy(gameObject);
            //meter animacion muerte antes del destroy y el num de segundos el de la animacion.
        }

    }
    private void OnDrawGizmosSelected()
    {
        //Ver el radio del ataque de la espada
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoAtaque.position, misDatos.distanciaAtaque);
    }
}
