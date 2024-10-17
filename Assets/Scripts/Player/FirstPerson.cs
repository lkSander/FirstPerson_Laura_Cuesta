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
       movimiento= new Vector3(h,0,v).normalized;

        float anguloRotacion= Mathf.Atan2(movimiento.x, movimiento.z)*  Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; //rotar el objeto para que siga los ejes de la cámara. Se usa trigonometría
        
        if(movimiento.magnitude >0)
        {
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime); //No va por físicas así que se usa con tiempo


        }
       
    }
}
