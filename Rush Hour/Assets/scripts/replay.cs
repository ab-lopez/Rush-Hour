using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replay : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameStart");
        }
    }
}
