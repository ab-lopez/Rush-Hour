using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Debug.Log("something here!!!");
        }
    }

}
