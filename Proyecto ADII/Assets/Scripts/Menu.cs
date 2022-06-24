using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public int mapa = 0;
   public void exitButton()
   {
        Application.Quit();
        Debug.Log("Saliendo");
   }

    public void starGame()
    {
        switch (mapa)
        {
            case 0:
                SceneManager.LoadScene("Map1");
                break;
            case 1:
                //SceneManager.LoadScene("Map1");
                Debug.Log("Mapa 2");
                break;
            case 2:
                //SceneManager.LoadScene("Map1");
                Debug.Log("Mapa 3");
                break;
            default:
                break;
        }
        
    }

    public void setMap(int speed)
    {
        switch (speed)
        {
            case 0:
                mapa = 0;
                Debug.Log("Mapa 1 seleccionado");
                break;
            case 1:
                mapa = 1;
                Debug.Log("Mapa 2 seleccionado");
                break;
            case 2:
                mapa = 2;
                Debug.Log("Mapa 3 seleccionado");
                break;
            default:
                mapa = 0;
                break;
        }
    }

    public void setRounds(int round)
    {
        switch (round)
        {
            case 0:
                Corredor.rondas = 3;
                Debug.Log("3 rondas");
                break;
            case 1:
                Corredor.rondas = 5;
                Debug.Log("5 rondas");
                break;
            case 2:
                Corredor.rondas = 7;
                Debug.Log("7 rondas");
                break;
            default:
                mapa = 0;
                break;
        }
    }



}
