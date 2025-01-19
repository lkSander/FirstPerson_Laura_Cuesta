using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    [SerializeField] GameObject EspadaFuego;
    
    private int indiceArmaActual;
    // Start is called before the first frame update
    float dinero;
    bool espadaEspecial=false;
    void Start()
    {
        dinero = GameObject.FindObjectOfType<CanvasManager>().Dinero;
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaRaton();
        CambiarArmaConTeclado();
       
        if(dinero>=200)
        {
            espadaEspecial = true;
        }
    }
    private void CambiarArmaConTeclado()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);

        }
        if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);

        }
        if ((Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && espadaEspecial == true)
        {
            CambiarArma(2);
            
            EspadaFuego.SetActive(true);

        }

        //if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        //{
        //    CambiarArma(3);
            

        //}
        
        //if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        //{
        //    CambiarArma(3);
        //}

    }
    private void CambiarArma(int indiceNuevaArma)
    {
        armas[indiceArmaActual].SetActive(false);



        

        //if (indiceNuevaArma < 0)
        //{
        //    indiceArmaActual = armas.Length - 1;
        //}
        //else if (indiceNuevaArma > armas.Length - 1)
        //{
        //    indiceArmaActual = 0;
        //}

      

        if (indiceNuevaArma < 0)
        {
            indiceNuevaArma = armas.Length - 1;
        }
        else if (indiceNuevaArma > armas.Length - 1)
        {
            indiceNuevaArma = 0;
        }

        armas[indiceNuevaArma].SetActive(true);
        indiceArmaActual = indiceNuevaArma;
    }

    private void CambiarArmaRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel")  ;

        if(scrollWheel>0)
        {
            CambiarArma(indiceArmaActual + 1);
        }
        else if(scrollWheel<0)
        {
            CambiarArma(indiceArmaActual - 1);
        }
    }
}
