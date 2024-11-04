using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private float h;
    private float v;
    CharacterController controller;
   private Vector3 movimiento;
    [SerializeField] float smoothTime;
    [SerializeField] float velocidadRotacion;
    float anguloSuave;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverRotar();
        AplicarGravedad();
    }
    private void MoverRotar()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movimiento = new Vector2(h, v).normalized;



        // float anguloRotacion= Mathf.Atan2(movimiento.x, movimiento.z)*  Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; //rotar el objeto para que siga los ejes de la cámara. Se usa trigonometría

        if (movimiento.magnitude > 0)
        {
            //Calculo el águlo al que ponerse en funcionamiento

            float anguloRotacion = Mathf.Atan2(movimiento.x, movimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            anguloSuave= Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion,  ref velocidadRotacion , smoothTime);

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 mov = Quaternion.Euler(0, anguloSuave, 0) * Vector3.forward;

            controller.Move(mov * velocidadMovimiento * Time.deltaTime); //No va por físicas así que se usa con tiempo


        }

    }
    private void AplicarGravedad()
    {
        movVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movVertical * Time.deltaTime);
    }
}
