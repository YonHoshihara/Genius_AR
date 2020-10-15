using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] table_elements; 
    void Start()
    {
        generate_sequence(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<int> generate_sequence(int sequence_size) {
        
        List<int> sequence  = new List<int>();
        float generated_number = 0;
        int table_elements_lengh = table_elements.Length;
        for (int i=0; i<=sequence_size+1; i++){
            generated_number =Random.Range(0, table_elements_lengh);
            
            Debug.Log(generated_number);
            //sequence.Add(generated_number);   
        }
       
        return sequence;
    }

}
