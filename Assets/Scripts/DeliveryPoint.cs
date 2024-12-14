using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDelivery playerDelivery = other.GetComponent<PlayerDelivery>();
            if (playerDelivery != null && playerDelivery.HasCake)
            {
                playerDelivery.DeliverCake();
            }
        }
    }


}
