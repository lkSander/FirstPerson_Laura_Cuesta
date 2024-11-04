using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    private Vector3 movimiento;
    [SerializeField] float smoothTime;
    [SerializeField] float velocidadRotacion;
    float anguloSuave;

    [SerializeField] private float vidas;
    


    private float h;
    private float v;
    
   
    [Header("Detección de Suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Vector3 movVertical;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;



    void Start()
    {
        
        controller = GetComponent<CharacterController>();

        ///Boquear el ratón y que no se vea
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoverRotar();
        AplicarGravedad();
        if(EnSuelo()==true )
        {
            movVertical.y= 0;
            Saltar();
        }
       

    }
    private void MoverRotar()
    {
       h= Input.GetAxisRaw("Horizontal");
       v= Input.GetAxisRaw("Vertical");
       movimiento = new Vector3(h,v,0).normalized;

        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        
       

       // float anguloRotacion= Mathf.Atan2(movimiento.x, movimiento.z)*  Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; //rotar el objeto para que siga los ejes de la cámara. Se usa trigonometría
        
        if(movimiento.magnitude >0)
        {
            //Calculo el águlo al que ponerse en funcionamiento
            float anguloRotacion = Mathf.Atan2(movimiento.x, movimiento.y) * Mathf.Rad2Deg+ Camera.main.transform.eulerAngles.y;
            //transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

            Vector3 mov = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(mov * velocidadMovimiento * Time.deltaTime); //No va por físicas así que se usa con tiempo


        }


       
    }
    private void AplicarGravedad()
    {
        movVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movVertical * Time.deltaTime);
    }
    private bool EnSuelo()
    {
        //Tirar una esfera de detección en los piescon cierto radio
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }

    private void Saltar()
    {
        //saltar la cantidad que quieras
       if( Input.GetKeyDown(KeyCode.Space))
        {
            movVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
    }

    public void RecibirDanio(float danioEnemigo)
    {

        vidas-= danioEnemigo;


        
    }



}
