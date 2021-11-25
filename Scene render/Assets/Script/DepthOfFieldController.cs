using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DepthOfFieldController : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;
    
    public PostProcessVolume volume;
    DepthOfField depthOfField;

    [Range(0,5)] public float focusSpeed;



    //RayCast.cs references
    private RayCast rayResult;
    string objectName;
    string objectTag;
    string sentence;

    //Dialouge
    public Dialoguesystem Dialogue;







    // Start is called before the first frame update
    void Start()
    {
        
        volume.profile.TryGetSettings(out depthOfField);
    }




    // Update is called once per frame
    void Update()
    {
        
        raycast = new Ray(transform.position, transform.forward * 100);

        isHit = false;

        if (Physics.Raycast(raycast, out hit, 10f))
            {
                isHit = true;
                hitDistance = Vector3.Distance(transform.position, hit.point);


        }



        else
        {
                if (hitDistance < 10f)
                {
                    hitDistance++;
                }

        }
            
        

        objectName = hit.collider.name;
        objectTag = hit.collider.tag;
        

        rayResult.ray(hitDistance, objectName, objectTag, isHit, hit);
            
 
       



        SetFocus();
        

        
    }


    private void LateUpdate()
    {
        
    }




    void SetFocus()
    {
        
        
            depthOfField.focusDistance.value = Mathf.Lerp( depthOfField.focusDistance.value, hitDistance,Time.deltaTime * focusSpeed ) ;
        

    }


  

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.5f);

            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100f);
        }
    }

    public void Awake()
    {
        rayResult = GameObject.FindObjectOfType<RayCast> ();

 

        }

    }

