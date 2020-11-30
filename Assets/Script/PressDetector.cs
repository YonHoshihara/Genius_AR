using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController controller;
    public LevelController level_controller;
    private Animator anim;
    public GameObject glow_object;
    private SoundController sc;
    private Renderer rd;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sc = glow_object.GetComponent<SoundController>();
        rd = glow_object.GetComponent<Renderer>();
    }


    void OnMouseDown()
    {
        if (level_controller.can_i_press)
        {
            StartCoroutine(press_feedback());
        }
    }
    IEnumerator press_feedback()
    {
 
        controller.active_sequence_checker(gameObject.tag);
        //sc.playRoarSound();
        anim.SetTrigger("touched");
        sc.playRoarSound();
        rd.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.5f);
        rd.material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(1f);
         
    } 


}
