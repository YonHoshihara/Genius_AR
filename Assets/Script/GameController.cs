using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public int sequence_size;
    public float score_correct;
    public GameObject [] table_elements; 
    public SequenceController sequence_controller;
    public ScoreController score_controller;
    public GameObject error_feedback;
    public GameObject correct_feedback;
    public GameObject failed_feedback;
    public GameObject all_correct_feedback;
    public int max_error;
    private int sequence_counter;
    private int[] current_sequence;
    private string[] current_sequence_tags;
    private int error_counter = 1;
    public LevelController level_controller;
    void Start() {
        
        reset_sequence();
    }

    public void Update()
    {
   
    }
    private void reset_sequence()
    {
        sequence_counter = 0;
        current_sequence = sequence_controller.generate_sequence(2, table_elements);
        current_sequence_tags = sequence_controller.get_sequence_tags(current_sequence, table_elements);
    }

    private void update_sequence(){
        sequence_counter = 0;
        current_sequence = sequence_controller.update_sequence(sequence_controller.sequence_update_lenght,table_elements);
        current_sequence_tags = sequence_controller.get_sequence_tags(current_sequence, table_elements);
    }
    public void play_sequence(){

        if (gameObject.activeSelf)
        {
            sequence_controller.play_sequence(current_sequence, table_elements);
        }
    }

    public void active_sequence_checker(string table_element_tag)
    {

        StartCoroutine(sequence_checker(table_element_tag));
    }
    
    private IEnumerator sequence_checker(string table_element_tag)
    {
        if (sequence_counter <= (current_sequence_tags.Length-1))
        {

            if (current_sequence_tags[sequence_counter] == table_element_tag)
            {
                if(sequence_counter != current_sequence_tags.Length -1)
                {
                    feedback_show(correct_feedback, 1f);
                }
                score_controller.add_score(score_correct);
                sequence_counter++;

            }
            else
            {

                level_controller.can_i_press = false;
                if (error_counter < max_error)
                {
                    feedback_show(error_feedback, 1f);               
                    error_counter++;
                    yield return new WaitForSeconds(2f);
                    play_sequence();
                    sequence_counter = 0;
                }
                else
                {
                    level_controller.can_i_press = false;
                    feedback_show(failed_feedback, 1f);
                    Debug.Log("Errado e resetado");
                    reset_sequence();
                }
               
            }
        }
        
        
        if(sequence_counter == current_sequence_tags.Length) 
        {
            level_controller.can_i_press = false;
            feedback_show(all_correct_feedback, 1f);
            score_controller.add_score(score_correct);
            update_sequence();
            Debug.Log("Tudo Correto");   
        }
        yield return new WaitForSeconds(.01f);
    }
    public void feedback_show(GameObject obj, float time)
    {
        StartCoroutine(instantiate_on_time(obj, time));
    }
    
    public void load_scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public IEnumerator instantiate_on_time(GameObject obj, float time)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
    
}   
