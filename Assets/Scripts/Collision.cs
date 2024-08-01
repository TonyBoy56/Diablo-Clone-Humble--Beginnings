using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // start of the trigger event
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstruction")
        {
            print("ENTER");
        }
    }

    // during the trigger event
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "obstruction")
        {
            print("STAY");
        }
    }

    // ending the trigger event
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstruction")
        {
            print("EXIT");
        }
    }
}
