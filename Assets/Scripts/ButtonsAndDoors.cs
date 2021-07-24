using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script should be a component of a trigger.
 * In this game's case, this means that this script
 * should be assigned to an invisible box above a button.
 */

public class ButtonsAndDoors : MonoBehaviour
{
    public Material buttonPressedMaterial;
    public GameObject button;
    public GameObject door;
    private bool buttonPressed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (!buttonPressed)
            {
                GetComponent<AudioSource>().Play();
                button.transform.GetComponent<Renderer>().material = buttonPressedMaterial;
                door.transform.localPosition += new Vector3(0, -5.5f, 0);
            }
            buttonPressed = true;
        }
    }


}
