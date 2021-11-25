using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    //dialogues
    public Text Distance;
    public Text DialogueBox;
    private string[] Dialogue;
    private Queue<string> sentences;
    public GameObject box;
    public GameObject[] charNum;
    public float repeatReset;
    private Dialoguesystem passer;


    //head follow
    public GameObject head;
    public float LerpTime;
    private bool shouldAim = false;


    

    //billboard
    

   
    





    private void Start()
    {
        sentences = new Queue<string>();
        passer = GameObject.FindObjectOfType<Dialoguesystem>();

    }

    public void ray(float hitDistance, string name, string tag, bool billboardLit, RaycastHit raycastHit)
    {
        



        if (tag == "char")
        {
            Dialogue = raycastHit.collider.GetComponent<Dialoguesystem>().sentences;
            repeatReset = raycastHit.collider.GetComponent<Dialoguesystem>().repeat;
            Debug.Log(repeatReset);
         
            



            Distance.text = "\n" + raycastHit.collider.name + " : Press C to chat" ;
            if (Input.GetKeyDown(KeyCode.C))
            {




                if (repeatReset == 1)
                {

                    foreach (string sentence in Dialogue)
                    {

                        sentences.Enqueue(sentence);
                      
                        Debug.Log(sentence);
                        raycastHit.collider.GetComponent<Dialoguesystem>().repeat = 0;



                    }
                    
                }
               









                DisplaySentence();

            }

        }
        else
        {
            Distance.text = "";
        }



    }

    public void Reset()
    {
        repeatReset = 0;
        passer.passer(repeatReset);
    }

    public void DisplaySentence()
    {
        if (sentences.Count > 10000)
        {
            DialogueBox.text = "";
            box.SetActive(false);
            shouldAim = false;
        }
        else
        {
            string sentence = sentences.Dequeue();
            DialogueBox.text = sentence;
           
            box.SetActive(true);


            head.GetComponent<AimConstraint>().enabled = true;
            shouldAim = true;



        }

    }

    private void Update()
    {
        if (shouldAim == true)
        {
            headAim();
           
        }
        else
        {
            headUnAim();
        }

    }

    private void headAim()
    {
        head.GetComponent<AimConstraint>().weight = Mathf.Lerp(head.GetComponent<AimConstraint>().weight, 0.7f, Time.deltaTime * LerpTime);
    }

    private void headUnAim()
    {
        head.GetComponent<AimConstraint>().weight = Mathf.Lerp(head.GetComponent<AimConstraint>().weight, 0f, Time.deltaTime * LerpTime);
    }






}