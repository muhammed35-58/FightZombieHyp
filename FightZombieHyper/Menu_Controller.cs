using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Controller : MonoBehaviour
{

    [SerializeField] GameObject m_Panel;


    [SerializeField] int MenuPastTime = 0;
    
   
    void Update()
    {
        if (Black_Controller.IsDeath)
        {
            StartCoroutine(A());
        }
    }


    IEnumerator A()
    {
        yield return new WaitForSeconds(MenuPastTime);
        Time.timeScale = 0;
        m_Panel.SetActive(true);

    }


    public void RestartButtonMethod()
    {
        Time.timeScale = 1;
       Scene m_Scene;
       m_Scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(m_Scene.buildIndex);

    }

    public void ExitButtonMethod()
    {
        Application.Quit();
    }

}
