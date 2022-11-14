using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperController : MonoBehaviour
{

    private Touch my_Touch;
    [SerializeField] Animator hyper_Animator;

    [SerializeField] float TouchSpeedIdentifier;
    [SerializeField] float Translate_Speed;

    [SerializeField] float DirectionSpeed;



    void Update()
    {
        MyTouchPhase();
    }


    public void MyTouchPhase()
    {
        if (Input.touchCount > 0)
        {

            TouchController();
            transform.Translate(0f, 0f, Translate_Speed * Time.deltaTime);



            if (my_Touch.phase == TouchPhase.Began)
            {

                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                hyper_Animator.SetBool("IsRun", true);

            }

            if (my_Touch.phase == TouchPhase.Moved)
            {

                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                hyper_Animator.SetBool("IsRun", true);


            }

            if (my_Touch.phase == TouchPhase.Stationary)
            {

                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                hyper_Animator.SetBool("IsRun", true);


            }

            if (my_Touch.phase == TouchPhase.Ended)
            {

                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                hyper_Animator.SetBool("IsRun", false);

            }

        }
    }


    void TouchController()
    {

        if (Input.touchCount > 0)
        {

            my_Touch = Input.GetTouch(0);

            if (my_Touch.deltaPosition.x >= 50f)


                gameObject.transform.position = new Vector3
               (
                  gameObject.transform.position.x + my_Touch.deltaPosition.x * TouchSpeedIdentifier * Time.deltaTime,
                  gameObject.transform.position.y,
                  gameObject.transform.position.z + my_Touch.deltaPosition.y * TouchSpeedIdentifier * Time.deltaTime

               );

            gameObject.transform.Rotate(Vector3.up * my_Touch.deltaPosition.x * (DirectionSpeed * Time.deltaTime * 0.1f));

        }

        if (my_Touch.deltaPosition.x < 50f)
        {

            gameObject.transform.position = new Vector3

          (
            gameObject.transform.position.x + my_Touch.deltaPosition.x * TouchSpeedIdentifier * Time.deltaTime,
            gameObject.transform.position.y,
            gameObject.transform.position.z + my_Touch.deltaPosition.y * TouchSpeedIdentifier * Time.deltaTime

          );


            gameObject.transform.Rotate(Vector3.up * my_Touch.deltaPosition.x * (DirectionSpeed * Time.deltaTime * 0.5f));


        }







    }


}







