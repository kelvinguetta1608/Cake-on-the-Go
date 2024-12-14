using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDelivery : MonoBehaviour
{
    public bool HasCake = true;
    public int score = 0;   

    public void DeliverCake()
    {
        if (HasCake)
        {
            Debug.Log("Entrega Completada");
            score += 100;
            HasCake = false;
        }
    }
    
}
