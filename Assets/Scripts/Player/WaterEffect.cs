using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Volume volume;
    private LensDistortion distortionEffect;
    // Start is called before the first frame update
    void Start()
    {
      volume=  GetComponent<Volume>();
       if( volume.profile.TryGet(out LensDistortion lensDistorsion))
       {
            distortionEffect =lensDistorsion;
       }
        
    }

    // Update is called once per frame
    void Update()
    {
        FloatParameter ejemplo = new FloatParameter((1+Mathf.Sin(velocidad*Time.time))/2);
        FloatParameter ejemplo2 = new FloatParameter((1+Mathf.Cos(velocidad*Time.time))/2);
        distortionEffect.xMultiplier.SetValue(ejemplo);
        distortionEffect.yMultiplier.SetValue(ejemplo2);
     
    }

  
}
