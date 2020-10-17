using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressDetector : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnMouseDown()
     {
         Debug.Log("HEEERe");
         print (gameObject.tag);    
     }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
