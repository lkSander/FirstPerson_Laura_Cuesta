using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class ArmaGris : MonoBehaviour
{
    //Atacar eneigo
    //Ventana de atacar
    [SerializeField] private ParticleSystem system;

    [SerializeField]LayerMask enemy;

    Animator animator;
    private bool ventanaAbierta = false;
    [SerializeField]  ArmaSO misDatos;
   
    
    [SerializeField] Transform puntoAtaque;
    [SerializeField] bool estaAtacando = false;


    float danioAtaque ;
    // Start is called before the first frame update
    void Start()
    {
        danioAtaque = misDatos.danioAtaque;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Atacar();
        //if(puedoDaniar == false)
        //{
        //    DetectarImpacto();
        //}

    }
    private void Atacar()
    {
        Debug.Log("fase");
        if (Input.GetMouseButton(0)&& !estaAtacando)
        {
            
            
            estaAtacando=true;
            animator.SetTrigger("Atacar");
            DetectarImpacto();
           // Debug.Log("fase");
        }
    }
    private void FinAtaque()
    {
       
        estaAtacando=false;
       // Debug.Log("fase");
    }

   

    private void DetectarImpacto()
    {

        //1.attack point referencia
        //2. recrear variable responsable al radio
        //3. variable que es dañable (layer)

        system.Play();
        Collider[] collDetectados = Physics.OverlapSphere(puntoAtaque.position, misDatos.distanciaAtaque, enemy);
        if (collDetectados.Length > 0)
        {
            //aplicar daño a todos los colliders
            for (int i = 0; i < collDetectados.Length; i++)
            {

               collDetectados[i].GetComponent<PedroZombie>().RecibirDanho(danioAtaque);
              // Debug.Log("Dadeujas");

            }
            //puedoDaniar = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Ver el radio del ataque de la espada
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoAtaque.position,misDatos.distanciaAtaque);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Enemy")&& ventanaAbierta==true)
    //    {

    //        Enemigo.RecibirDanho(misDatos.danioAtaque);
    //        Debug.Log("Dadeujas");
    //    }

    //}

    //private void AbrirVentana()
    //{
    //    ventanaAbierta = true;


    //}
    //private void CerrarVentana()
    //{
    //    ventanaAbierta = false;
    //}
}
