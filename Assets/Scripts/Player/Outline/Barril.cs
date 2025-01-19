using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Barril : MonoBehaviour
{
    
    [SerializeField] private GameObject monedasPlataPrefab;

   
    Animator anim;
    bool monedasSpawn=false;
    
     

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AbrirCaja()
    {
        
        
        anim.SetTrigger("Barril");
        Instantiate(monedasPlataPrefab,this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject,2.5f);
           
    }

}
