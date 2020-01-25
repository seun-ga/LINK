using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazeObject : MonoBehaviour
{
  
   public GameObject textClick;
    RaycastHit hit; // 광선에 맞은 물체의 정보
    public float MaxDistance=15f;
    int layerMask;

    Ray ray;

    void Start(){
        
        layerMask=1<<LayerMask.NameToLayer("clickableObject");
        
        ray=new Ray();
   
    }
    void Update () {
       
        ray.origin=this.transform.position;
        ray.direction=this.transform.forward;
        draw_Ray();
        
        if (Physics.Raycast(ray.origin, ray.direction, out hit, MaxDistance,layerMask)){
           textClick.SetActive(true); 
           Debug.Log(hit.collider.gameObject.name);
        }else{
            textClick.SetActive(false); 
        }

      

    
    }
    void draw_Ray(){

       Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.blue, 5f);

    }
 }





