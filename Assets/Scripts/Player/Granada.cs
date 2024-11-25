using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private float radioGranada;
    [SerializeField] private LayerMask daniableGranada;

    private Collider[] buffer= new Collider[120];
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        int explotadosDetectados = Physics.OverlapSphereNonAlloc(transform.position, radioGranada, buffer, daniableGranada);
        if(explotadosDetectados > 0)
        {
            for(int i = 0; i < explotadosDetectados; ++i)
            {
               if( buffer[i].TryGetComponent(out ParteEnemigo scriptHuesos))
               {
                    scriptHuesos.Explotar(fuerzaImpulso, transform.position, radioGranada, 3.5f);

               }
            }
        }
    }
}
