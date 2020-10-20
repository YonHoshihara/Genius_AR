using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pressed_identifier;
    public GameController controller;
    void OnMouseDown()
    {
        controller.sequence_checker(gameObject.tag);
    }
}
