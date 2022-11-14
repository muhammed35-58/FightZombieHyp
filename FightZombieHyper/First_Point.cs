using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class First_Point : MonoBehaviour
{

     public static  bool IsTrigger;
    
     public static  int CrossBorderFriendCount;


    void Start()
    {
        IsTrigger = false;
        CrossBorderFriendCount = 0;
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        CrossBorderFriendCount++;
    //        IsTrigger = true;

    //    }

    //    //if (collision.gameObject.CompareTag("Character"))
    //    //{
    //    //    IsTrigger = true;
    //    //}

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            IsTrigger = true;
            CrossBorderFriendCount++;

        }

    }

}
