using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private Animator animator;

   private float timer ;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
     
       cam = Camera.main;//MainCamera

        timer = misDatos.cadenciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetMouseButton(0)&& timer>= misDatos.cadenciaAtaque)
        {
            animator.SetTrigger(1);
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitInfo.transform.name);
                if (hitInfo.transform.TryGetComponent(out ParteEnemigo scriptEnemigo))
                {
                  scriptEnemigo.RecibirDanio(misDatos.danioAtaque);
                }


            }
            //animator.SetTrigger(2);

            timer = 0;
        }
    }
}
