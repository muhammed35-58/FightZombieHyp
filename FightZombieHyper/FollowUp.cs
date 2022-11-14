using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowUp : MonoBehaviour
{
   
    [SerializeField] GameObject VeryImportantObject;
    [SerializeField] GameObject TargetThirdPoint;
    [SerializeField] float DivideTime;


    private void Update()
    {

        gameObject.transform.position = VeryImportantObject.transform.GetChild(0).gameObject.transform.position
        + new Vector3(-4f, 2.5f, 0f);
        
   
        if (Friends.IsFriendFinalStage)
        {
    
            float m_time = Time.time / DivideTime;

   
            float SoftForward = Mathf.SmoothStep(gameObject.transform.position.x,
                                Friends.FollowUpCameraObject.transform.position.x - 6f, m_time);

            gameObject.transform.position = new Vector3(SoftForward, gameObject.transform.position.y + 1f,
                                            gameObject.transform.position.z);

        }



    }

}