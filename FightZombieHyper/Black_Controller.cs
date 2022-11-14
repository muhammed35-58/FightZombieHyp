using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Black_Controller : MonoBehaviour
{

    [SerializeField] HyperController Script_Hyper_Controller;

    public static List<GameObject> CurrentBlacks = new List<GameObject>();
    public static List<GameObject> friends = new List<GameObject>();
    [SerializeField] List<GameObject> Black_Enemys = new List<GameObject>();


    public GameObject o_ThirdPoint;

    [SerializeField] float offsetFloat;
    [SerializeField] float distance_Identifier;
    float WithDistance;


    public static bool IsBlackFinalStage;
  public static  bool IsDeath;

    int i;

    private void Start()
    {
        IsBlackFinalStage = false;
        IsDeath = false;

        foreach (var item in Black_Enemys)
        {
            CurrentBlacks.Add(item);
        }

    }

    void Update()
    {
       
        if (First_Point.IsTrigger)
        {
            ControllerEnd();
        }


        if (IsBlackFinalStage)
        {
            DeathBlack();
        }

    }


    void ControllerEnd()
    {
        Script_Hyper_Controller.enabled = false;

        for (int i = 0; i < CurrentBlacks.Count; i++)
        {

            CurrentBlacks[i].gameObject.GetComponent<Animator>().SetBool("IsRun", true);
            CurrentBlacks[i].gameObject.transform.GetComponent<NavMeshAgent>().SetDestination(o_ThirdPoint.transform.position);
            WithDistance = Vector3.Distance(CurrentBlacks[0].gameObject.transform.position, o_ThirdPoint.transform.position);

            if (WithDistance < distance_Identifier)
            {
                CurrentBlacks[i].gameObject.transform.GetComponent<Animator>().SetBool("IsPunch", true);
                CurrentBlacks[i].gameObject.transform.LookAt(o_ThirdPoint.gameObject.transform.position, Vector3.up);

                IsBlackFinalStage = true;
            }

            if (IsDeath)
            {
                CurrentBlacks.RemoveAt(i);
            }

        }

    }

    void DeathBlack()
    {

        for (int i = 0; i < CurrentBlacks.Count-1; i++)
        {
            CurrentBlacks[i].gameObject.GetComponent<Animator>().SetBool("DeathIs", true);
            Destroy(CurrentBlacks[i].gameObject, 3f);
            CurrentBlacks.RemoveAt(i);
        }

        IsDeath = true;

    }

}







