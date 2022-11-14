using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Friends : MonoBehaviour
{

    [SerializeField] Trigger_Controller b;

    [SerializeField] List<GameObject> o_BlackEnemys = new List<GameObject>();


    public GameObject Character;
    [SerializeField] Animator F_Anim;
    [SerializeField] GameObject ThirdPoint;
    [SerializeField] float ThirdPoint_Identifier;


    [SerializeField] float IdentifierDistance;
    [SerializeField] float f_DeathDistance;

    public static bool IsObstacleContact;
    [SerializeField] bool IsMySelfContact;
    [SerializeField] bool IsCharacterContact;


    public static bool IsFriendFinalStage;

    public static bool IsObstacle;
    public static GameObject CarpanObje;


    public static GameObject FollowUpCameraObject;


    Touch AllTouch;
    int i;

 
    void Start()
    {
        IsObstacleContact = false;
        IsMySelfContact = false;
        IsCharacterContact = false;

        IsFriendFinalStage = false;

        FollowUpCameraObject = GameObject.FindGameObjectWithTag("FollowUp");
        

    }


    private void Update()
    {

        if (IsCharacterContact)
        {
            CharacterAndFriendContact();
        }

        if (IsMySelfContact)
        {
            FriendAndFriendContact();
        }

        if (IsFriendFinalStage)
        {
            DeathFriend();
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.CompareTag("Character"))
        {
            IsCharacterContact = true;
        }


        if (collision.gameObject.transform.CompareTag("Player"))
        {
            IsMySelfContact = true;
        }

        if (collision.gameObject.transform.CompareTag("Enemy"))
        {
            F_Anim.Play("Death");
            Destroy(gameObject, 0.2f);

        }

        if (collision.gameObject.transform.CompareTag("Obstacle"))
        {
            CarpanObje = gameObject;
            F_Anim.Play("Death");
            Destroy(CarpanObje, 0.9f);
            Destroy(F_Anim, 0.9f);
            IsObstacle = true;
        }

    }

    void CharacterAndFriendContact()
    {
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.yellow;

        Character.transform.position = new Vector3(Character.transform.position.x, 0f, Character.transform.position.z);
        gameObject.transform.SetParent(Character.transform);

     
        Vector3 aBs = Character.transform.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(aBs.x, aBs.y, aBs.z);


        AllAnimasyonController();

        if (First_Point.IsTrigger)
        {
            EndGameFriendsAction();
        }

    }


    void FriendAndFriendContact()
    {

        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.yellow;

        Character.transform.position = new Vector3(Character.transform.position.x, 0f, Character.transform.position.z);

        gameObject.transform.SetParent(null);
          gameObject.transform.SetParent(Character.transform);
      

        Vector3 RBs = Character.transform.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(RBs.x, RBs.y, RBs.z);

        AllAnimasyonController();


        if (First_Point.IsTrigger)
        {
           
            EndGameFriendsAction();
        }

      
    }


  

    void AllAnimasyonController()
    {

        if (Input.touchCount > 0)
        {

            AllTouch = Input.GetTouch(0);

            if (AllTouch.phase == TouchPhase.Began)
            {
                F_Anim.SetBool("IsRush", true);
            }

            if (AllTouch.phase == TouchPhase.Moved)
            {
                F_Anim.SetBool("IsRush", true);
            }

            if (AllTouch.phase == TouchPhase.Stationary)
            {
                F_Anim.SetBool("IsRush", true);

            }

            if (AllTouch.phase == TouchPhase.Ended)
            {
                F_Anim.SetBool("IsRush", false);

            }


        }


    }



    void EndGameFriendsAction()
    {
       
        gameObject.transform.SetParent(null);
        gameObject.transform.SetParent(FollowUpCameraObject.gameObject.transform); // ==> FollowUp Script

        FollowUpCameraObject.transform.GetComponent<NavMeshAgent>().SetDestination(ThirdPoint.gameObject.transform.position);
       
        F_Anim.SetBool("IsRush", true);

        gameObject.transform.GetComponent<Rigidbody>().isKinematic = true; // BU KODU YENÝ YAZDIN.
        gameObject.transform.GetComponent<NavMeshAgent>().SetDestination(ThirdPoint.gameObject.transform.position);
     

        if (Vector3.Distance(gameObject.transform.position, ThirdPoint.transform.position) < ThirdPoint_Identifier)
        {

            F_Anim.SetBool("IsPunch", true);
            //  gameObject.transform.LookAt(o_BlackEnemys[i].gameObject.transform, Vector3.up);

            gameObject.transform.LookAt(ThirdPoint.gameObject.transform, Vector3.up);
          
        }

        IsFriendFinalStage = true;

      
    }


    void DeathFriend()
    {
        b.enabled = false;
        F_Anim.SetBool("IsDeath", true);
        Destroy(gameObject, 8f);
    }









}
