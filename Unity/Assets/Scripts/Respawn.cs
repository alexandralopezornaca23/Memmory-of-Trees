using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour //"respawn" es reaparecer.
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other) //cuando cualquier otra cosa entre en colision con la zona de muerte el personaje principal reaparecerá al inicio.
     //Si ubiera otros personajes o cosas este "other" no podria funcionar, se tendria que concretar.
    {
        if(other.CompareTag("Player")) //Arriba en el inspector del objeto en unity se puede cambiar los tags, lo hemos camviado a player.
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}
