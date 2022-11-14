using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trigger_Controller : MonoBehaviour
{

    [SerializeField] List<GameObject> o_Friends = new List<GameObject>();
    [SerializeField] List<GameObject> o_enemys = new List<GameObject>();
    [SerializeField] List<Animator> a_Enemys = new List<Animator>();
    [SerializeField] GameObject o_VeryImportantObject;
    [SerializeField] float d_Identifier;

    Vector3 m_EnemyDestinationPoint;
    Vector3 m_FriendDestinationPoint;
    float m_distance;
    int i;
    int j;

    public static bool tetikleyici;
    private void Start()
    {
        i = 0;
        j = 0;
        tetikleyici = false;
    }

    private void Update()
    {
        for (i = 0; i < o_Friends.Count; i++)
        {
            for (j = 0; j < o_enemys.Count; j++)
            {

         
                m_distance = Vector3.Distance(o_Friends[i].gameObject.transform.position, o_enemys[j].gameObject.transform.position);


                if (m_distance < d_Identifier)
                {
                    tetikleyici = true;

                    if (tetikleyici)
                    {
                        Encounter();
                    }

                }

                if (Friends.IsObstacle)
                {
                    o_Friends.Remove(Friends.CarpanObje);                  
                }

            }

        }


    }

    public void Encounter()
    {
        o_Friends[i].gameObject.GetComponent<Friends>().enabled = false;
        o_Friends[i].gameObject.transform.SetParent(null);
       
        o_Friends[i].gameObject.GetComponent<Animator>().SetBool("IsRush", true);
        a_Enemys[j].SetBool("IsRace", true);

        o_enemys[j].gameObject.transform.LookAt(o_Friends[i].gameObject.transform);
        o_Friends[i].gameObject.transform.LookAt(o_enemys[j].gameObject.transform, Vector3.up);

        m_EnemyDestinationPoint = o_enemys[j].gameObject.transform.TransformPoint(Vector3.forward * 3f);
        m_FriendDestinationPoint = o_enemys[j].gameObject.transform.TransformPoint(Vector3.forward * 2.8f);

        o_Friends[i].gameObject.GetComponent<NavMeshAgent>().SetDestination(m_FriendDestinationPoint);
        o_enemys[j].gameObject.GetComponent<NavMeshAgent>().SetDestination(m_EnemyDestinationPoint);

        o_Friends.RemoveAt(i);
        o_enemys.RemoveAt(j);
     
        a_Enemys.RemoveAt(j);
    }
}
