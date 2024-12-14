using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastel : MonoBehaviour
{
    [Header("Vida del Pastel")]
    public int vida = 4; 
    
    public void ReducirVida(int cantidad)
    {
        vida-= cantidad;
        Debug.Log("Vida Restante" + vida);

        if (vida <= 0) 
        {
            DestruirPastel();
        }
    }


    void DestruirPastel()
    {
        Debug.Log("El pastel se ha destruido");
    }
}
