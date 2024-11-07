using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArmaManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    
    private Animator animator;


    private Camera cam;
    void Start()
    {
        animator=GetComponent<Animator>();  
        cam = Camera.main;//MainCamera
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger(1);
            system.Play();
           if( Physics.Raycast(cam.transform.position,cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitInfo.transform.name);
                if(hitInfo.transform.CompareTag("PartEnemy"))
                {
                    hitInfo.transform.GetComponent<PedroZombie>().RecibirDanho(misDatos.danioAtaque);
                }
               

            }
           animator.SetTrigger(2);
        }
    }
}
