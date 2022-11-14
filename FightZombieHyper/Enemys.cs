using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemys : MonoBehaviour
{
  

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {

            gameObject.GetComponent<Animator>().Play("Death");
          
            Destroy(gameObject, 0.2f);
         
        }
    } */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {

            gameObject.GetComponent<Animator>().Play("Death");

            Destroy(gameObject, 0.2f);

        }
    }

}

