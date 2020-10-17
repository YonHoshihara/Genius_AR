using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int sequence_size;
    public GameObject [] table_elements; 
    public SequenceController sequenceController;

    private int[] current_sequence;
    void Start(){
        current_sequence = sequenceController.generate_sequence(sequence_size,table_elements);

        //sequenceController.play_sequence(current_sequence, table_elements);
    }

    public void play_sequence(){
        sequenceController.play_sequence(current_sequence, table_elements);
    }
}
