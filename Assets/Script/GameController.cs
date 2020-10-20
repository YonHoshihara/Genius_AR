using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int sequence_size;
    public GameObject [] table_elements; 
    public SequenceController sequence_controller;
    public ScoreController score_controller;
    private int sequence_counter;
    private int[] current_sequence;
    private string[] current_sequence_tags;
    void Start(){
        reset_sequence();
    }
    private void reset_sequence()
    {
        sequence_counter = 0;
        current_sequence = sequence_controller.generate_sequence(sequence_size, table_elements);
        current_sequence_tags = sequence_controller.get_sequence_tags(current_sequence, table_elements);
    }
    public void play_sequence(){
        sequence_controller.play_sequence(current_sequence, table_elements);
    }

    public void sequence_checker(string table_element_tag)
    {
       
        if (current_sequence_tags[sequence_counter] == table_element_tag)
        {
            Debug.Log("Correto");
            score_controller.add_score(10.0f);
            sequence_counter++;
        }
        else
        {
            Debug.Log("Errado");
            reset_sequence();

        }
    }

    public void feedback_point(GameObject obj, float time)
    {
       // StartCoroutine(instantiate_on_time(obj, time));
    }
    IEnumerable instantiate_on_time(GameObject obj, float time)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
        
    }
}
