using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject easy_table;
    [SerializeField] private GameObject medium_table;
    [SerializeField] private GameObject hard_table;
    [SerializeField] private GameObject level_menu;
    [SerializeField] private Animator level_menu_animator;
    public bool is_active_level_menu;
    public bool can_i_press;
  
    public void select_easy()
    {
        can_i_press = false;
        easy_table.SetActive(true);
        medium_table.SetActive(false);
        hard_table.SetActive(false);
        deactive_level_menu();
    }
    public void select_medium()
    {
        can_i_press = false;
        medium_table.SetActive(true);
        easy_table.SetActive(false);
        hard_table.SetActive(false);
        deactive_level_menu();
    }
    public void select_hard()
    {
        can_i_press = false;
        hard_table.SetActive(true);
        easy_table.SetActive(false);
        medium_table.SetActive(false);
        deactive_level_menu();
    }
    public void active_level_menu()
    {

        can_i_press = false;
        is_active_level_menu = true;
        level_menu_animator.SetTrigger("active");
    }
    public void deactive_level_menu()
    {
        is_active_level_menu = false;
        level_menu_animator.SetTrigger("deactive");
       
    }

}
