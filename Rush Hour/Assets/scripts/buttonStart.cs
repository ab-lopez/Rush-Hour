using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonStart : MonoBehaviour
{
    [SerializeField] GameObject train;

    private Animator animatorController;

    void Awake()
    {
        animatorController = train.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        //SceneManager.LoadScene("Game");
        animatorController.SetBool("playTransition", true);

    }

}
