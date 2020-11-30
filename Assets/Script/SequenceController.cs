using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public int sequence_update_lenght;
    private int sequence_correct;
    public LevelController level_controller;
    private List<int> sequence  = new List<int>();
    
    void Start (){

    }
    
    public int[] generate_sequence(int sequence_size, GameObject[] table_elements) {
        
        sequence  = new List<int>();
        int generated_number = 0;
        int table_elements_lengh = table_elements.Length;
        for (int i=0; i<sequence_size; i++){
            generated_number = Random.Range(0, table_elements_lengh);
            sequence.Add(generated_number);
        }
    
        return sequence.ToArray();
    }

    public int [] update_sequence(int sequence_update_size,GameObject[] table_elements){

        int generated_number = 0;
        int table_elements_lengh = table_elements.Length;
        for (int i=0; i<sequence_update_size; i++){
            generated_number = Random.Range(0, table_elements_lengh);
            sequence.Add(generated_number);
        }
        return sequence.ToArray();
    }

    public string[] get_sequence_tags(int [] sequence, GameObject[] table_elements){
        
        int index = 0;
        List<string> sequence_tags_vector = new List<string>();
        for (int i = 0; i<sequence.Length; i++){
            index = sequence[i];
            sequence_tags_vector.Add(table_elements[index].tag);

        }
        return sequence_tags_vector.ToArray();
    }
    public void play_sequence(int[] sequence,GameObject[] table_elements){
        
        StartCoroutine(show_sequence(sequence, table_elements));
    }

    private IEnumerator show_sequence(int[] sequence,GameObject[] table_elements){

        level_controller.can_i_press = false;
        int index = 0;
        for(int i = 0; i<sequence.Length;i++){
            index = sequence[i];
           
            PressDetector pd = table_elements[index].GetComponent<PressDetector>();
            Renderer mr = pd.glow_object.GetComponent<Renderer>();
            SoundController sc = pd.glow_object.GetComponent<SoundController>();
            Animator anim = table_elements[index].GetComponent<Animator>();
            sc.playRoarSound();
            anim.SetTrigger("touched");
            mr.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(.5f);
            mr.material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1f);
            
        }

        level_controller.can_i_press = true;
    }
}
