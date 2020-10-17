using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
     public int[] generate_sequence(int sequence_size, GameObject[] table_elements) {
        
        List<int> sequence  = new List<int>();
        int generated_number = 0;
        int table_elements_lengh = table_elements.Length;
        for (int i=0; i<sequence_size; i++){
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
        int index = 0;
        for(int i = 0; i<sequence.Length;i++){
            index = sequence[i];
            
            table_elements[index].SetActive(false);
            yield return new WaitForSeconds(.5f);
            table_elements[index].SetActive(true);
            yield return new WaitForSeconds(1f);
            
        }
    }

}
