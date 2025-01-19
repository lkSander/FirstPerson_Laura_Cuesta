using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    bool pressed = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Game();
    }
    public void Game()
    {
        if(Input.GetKeyDown(KeyCode.Space) || pressed==true)
        {
            
            SceneManager.LoadScene(1);
        }
       
    }
        
    public void Pressed()
    {
        pressed = true;

    }
}

