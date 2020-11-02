using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController controller;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        if (controller.can_i_press)
        {
            controller.sequence_checker(gameObject.tag);
            anim.SetTrigger("touched");
        }
    }

}
