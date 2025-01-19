
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paja : MonoBehaviour
{
    Animator anim;
    int probabilidad;
    [SerializeField] GameObject monedasOroPrefab;
    [SerializeField] GameObject monedasPlataPrefab;
   
    public void Busqueda()
    {
        Debug.Log("Preanimar");
        

        if (probabilidad==1)
        {
            
            Instantiate(monedasOroPrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 1);

            
        }
        else if(probabilidad==2)
        {
            Instantiate(monedasPlataPrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 1);

        }
        else
        {
            Destroy(gameObject, 0.2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        probabilidad = Random.Range(0, 4);
    }


}
