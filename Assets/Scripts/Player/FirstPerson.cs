using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private float h;
    private float v;
    CharacterController controller;
    Vector3 movimiento;

    
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverRotar();
    }
    void MoverRotar()
    {
       h= Input.GetAxisRaw("Horizontal");
       v= Input.GetAxisRaw("Vertical");
       movimiento = new Vector3(h,v,0).normalized;

       

       // float anguloRotacion= Mathf.Atan2(movimiento.x, movimiento.z)*  Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; //rotar el objeto para que siga los ejes de la c�mara. Se usa trigonometr�a
        
        if(movimiento.magnitude >0)
        {
            //Calculo el �gulo al que ponerse en funcionamiento
            float anguloRotacion = Mathf.Atan2(movimiento.x, movimiento.y) * Mathf.Rad2Deg+ Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 mov = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime); //No va por f�sicas as� que se usa con tiempo


        }
       
    }
}
