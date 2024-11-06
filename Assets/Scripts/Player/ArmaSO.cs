using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Arma")]
public class ArmaSO :ScriptableObject
{
    //DATOS

    public int municionCargada;
    public int municionCartucho;
    public float cadenciaAtaque;
    public float distanciaAtaque;
    public float danioAtaque;
}
