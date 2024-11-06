using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ArmaSO misDatos;
    


    private Camera cam;
    void Start()
    {
        cam = Camera.main;//MainCamera
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
           if( Physics.Raycast(cam.transform.position,cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
