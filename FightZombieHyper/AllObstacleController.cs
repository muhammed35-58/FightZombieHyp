using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObstacleController : MonoBehaviour
{
    [SerializeField] GameObject Character;
    [SerializeField] GameObject VeryImportantobject;

    [SerializeField] List<GameObject> o_Door = new List<GameObject>();

    [SerializeField] GameObject m_clockOcstacle;
    [SerializeField] GameObject[] o_Arrows;
    [SerializeField] GameObject[] m_CannonBalls;
    [SerializeField] ParticleSystem ParticleCannonBalls;



    [SerializeField] float min;
    [SerializeField] float max;
    [SerializeField] float SpeedDeltaTime;

    [SerializeField] float xPosValue;
    [SerializeField] float yPosValue;
    [SerializeField] float Distance_Identifier;


    [SerializeField] float PingPongExitTime;
    float time_ping;
    float m_time;

    int i;
    int j;

    private void Start()
    {
        i = 0;
        j = 0;

    }

    private void Update()
    {

        //   float Currentdistance = Vector3.Distance(Character.transform.position, o_Door[2].transform.position);

        float Currentdistance = Vector3.Distance(VeryImportantobject.transform.GetChild(0).position, o_Door[2].transform.position);

        if (Currentdistance < Distance_Identifier)
        {

            for (int  i = 0; i < o_Door.Count; i++)
            {
                o_Door[i].gameObject.transform.Rotate(new Vector3(90f, 0f, 0f) * Time.deltaTime * SpeedDeltaTime);
            }
        }



        //   float CurrentDistanceTwo = Vector3.Distance(Character.transform.position, o_Arrows[0].gameObject.transform.position);

        float CurrentDistanceTwo = Vector3.Distance(VeryImportantobject.transform.GetChild(0).position, o_Arrows[0].transform.position);

        if (CurrentDistanceTwo < Distance_Identifier)
        {

            for (int i = 0; i < o_Arrows.Length; i++)
            {
                o_Arrows[i].gameObject.transform.localPosition = new Vector3(xPosValue, yPosValue,
                                                             Mathf.Lerp(min, max, m_time));

                m_time += 0.5f * Time.deltaTime;

                if (m_time > 1)
                {
                    float dgr = max;
                    max = min;
                    min = dgr;
                    m_time = 0.0f;
                }

            }

        }

  


        time_ping = Time.time;

        // float CurrentDistanceFour = Vector3.Distance(Character.transform.position, m_CannonBalls[i].transform.position);
         float CurrentDistanceFour = Vector3.Distance(VeryImportantobject.transform.GetChild(0).transform.position, m_CannonBalls[i].transform.position);


        if (CurrentDistanceFour < 30f)
        {
            

            if (time_ping > 0f)
            {
                j = 0;

                while (j < m_CannonBalls.Length)
                {

                    m_CannonBalls[j].transform.Rotate(Vector3.up);


                    float m_PingPong = Mathf.PingPong(Time.time, PingPongExitTime);

                    m_CannonBalls[j].transform.position = new Vector3(m_CannonBalls[j].transform.position.x, m_PingPong + 0.75f,
                                                       m_CannonBalls[j].transform.position.z);

                    m_CannonBalls[j].transform.localScale = new Vector3(m_PingPong, m_PingPong, m_PingPong);


                    time_ping = 0.0f;

                    j++;

                }

            }

        }

        else
        {
            ParticleCannonBalls.gameObject.SetActive(false);
        }


        float CurretDistanceFive = Vector3.Distance(VeryImportantobject.gameObject.transform.GetChild(0).transform.position,
                                                     m_clockOcstacle.gameObject.transform.position);

        if (CurretDistanceFive < 30f)
        {
            m_clockOcstacle.gameObject.transform.GetComponent<Animator>().enabled = true;
        }

    }

}




