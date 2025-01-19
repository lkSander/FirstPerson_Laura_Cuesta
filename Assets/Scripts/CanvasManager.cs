using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject canvaSettings;
    [SerializeField] Button play;
    [SerializeField] Button close;

    [SerializeField] TMP_Text monedas;
    [SerializeField] TMP_Text vidasText;
    [SerializeField] TMP_Text timeText;
    [SerializeField]float dinero;
    [SerializeField]float objetivoDinero;
    [SerializeField]float time;
    float vidasPersonaje;
    float vidas;

    public float Dinero { get => dinero; set => dinero = value; }

    // Start is called before the first frame update
    private void Start()
    {
        //Me busca el primer gameobject tipo FirstPerson 
        Time.timeScale = 1;

    }
    private void Update()
    {
        vidas = GameObject.FindObjectOfType<FirstPerson>().Vidas;

        Settings();

        time -= Time.deltaTime;
        monedas.SetText("" + dinero+"/ "+objetivoDinero);
        vidasText.SetText("" + vidas);
        timeText.SetText("Timer: " + time);

        if(dinero>= objetivoDinero&& time<=0)
        {
            SceneManager.LoadScene(3);
        }
        else if(time<=0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void Settings()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            
            
            Cursor.lockState = CursorLockMode.None;
            canvaSettings.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void Play()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        canvaSettings.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
   
    private void Hud()
    {

    }
}
