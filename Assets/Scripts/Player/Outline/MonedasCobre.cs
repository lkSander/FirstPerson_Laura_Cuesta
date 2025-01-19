using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonedasCobre : MonoBehaviour
{
    [SerializeField] float valorMon;

    float dinero;
    // Start is called before the first frame update
    void Start()
    {
        //dinero = GameObject.FindObjectOfType<CanvasManager>().Dinero;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<CanvasManager>().Dinero += valorMon;

            Destroy(gameObject);
        }
    }
}
