using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSourceSfx;

    public void ReproducirSonido(AudioClip clip)
    {
        //1Vez
        audioSourceSfx.PlayOneShot(clip);
    }
}
