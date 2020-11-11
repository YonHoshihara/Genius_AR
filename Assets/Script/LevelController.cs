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
 
    IEnumerator Start()
    {
        while (true)
        {
         
            yield return new WaitForSeconds(.1f);

        }
    }

    public void select_easy()
    {
        easy_table.SetActive(true);
        medium_table.SetActive(false);
        hard_table.SetActive(false);
        deactive_level_menu();
    }
    public void select_medium()
    {
        medium_table.SetActive(true);
        easy_table.SetActive(false);
        hard_table.SetActive(false);
        deactive_level_menu();
    }
    public void select_hard()
    {
        hard_table.SetActive(true);
        easy_table.SetActive(false);
        medium_table.SetActive(false);
        deactive_level_menu();
    }
    public void active_level_menu()
    {
        level_menu_animator.SetTrigger("active");
    }
    public void deactive_level_menu()
    {
        level_menu_animator.SetTrigger("deactive");
    }
    // Update is called once per frame
  
    void Update()
    {
        
    }
}
