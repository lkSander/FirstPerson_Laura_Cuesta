using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || pressed == true)
        {

            SceneManager.LoadScene(0);
        }
    }
    public void RetryGame()
    {
        pressed = true;
    }
}
