using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int sequence_size;
    public GameObject [] table_elements; 
    public SequenceController sequence_controller;
    public ScoreController score_controller;
    public GameObject error_feedback;
    public GameObject correct_feedback;
    public GameObject failed_feedback;
    public int max_error;
    private int sequence_counter;
    private int[] current_sequence;
    public bool can_i_press;
    private string[] current_sequence_tags;
    private int error_counter = 1;
    void Start() {
        reset_sequence();
    }

    public void Update()
    {
        can_i_press = sequence_controller.can_i_press;
    }
    private void reset_sequence()
    {
        sequence_counter = 0;
        current_sequence = sequence_controller.generate_sequence(sequence_size, table_elements);
        current_sequence_tags = sequence_controller.get_sequence_tags(current_sequence, table_elements);
    }
    public void play_sequence(){

        if (gameObject.activeSelf)
        {
            sequence_controller.play_sequence(current_sequence, table_elements);
        }
    }
    public void sequence_checker(string table_element_tag)
    {
        if (sequence_counter < current_sequence_tags.Length)
        {
            if (current_sequence_tags[sequence_counter] == table_element_tag)
            {
                feedback_show(correct_feedback, 1f);
                score_controller.add_score(10.0f);
                sequence_counter++;
            }
            else
            {
                if (error_counter < max_error)
                {
                    feedback_show(error_feedback, 1f);               
                    error_counter++;
                    play_sequence();
                    sequence_counter = 1;
                }
                else
                {
                    feedback_show(failed_feedback, 1f);
                    Debug.Log("Errado e resetado");
                    reset_sequence();
                }
            }
        }
        else
        {
            Debug.Log("Tudo Correto");
        }
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
