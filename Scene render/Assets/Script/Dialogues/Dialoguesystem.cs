using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialoguesystem : MonoBehaviour
{




    [TextArea(3, 10)]
    public string[] sentences;
  
    
        public float repeat;
  







    public void passer(float repeatReset)
    {
        repeat = repeatReset;
        repeat = 0;
     
    }









}

