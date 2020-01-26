using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetoClick : MonoBehaviour
{

    public GameObject player;
    int originalY;
    public int moveSpeed = 15;
    // Start is called before the first frame update
    public int stopDistance=10;
    

   void Start(){
   
   }
   
   public void callMovePosition(Transform target){
       StartCoroutine(MovePosition(target));
   } 

   IEnumerator MovePosition(Transform target){

       float count =0;
       Vector3 prevPos=player.transform.position;
       Vector3 targetPos=new Vector3(target.position.x, player.transform.position.y, target.position.z);
       //y는 유지하여, 땅 밑으로 사라지지 않게 한다. 지형에 높이 변화가 있는 경우 바꿔야함
       
        while(true){

            count += (Time.deltaTime)/3;
            player.transform.position=Vector3.Lerp(prevPos,targetPos,count);
            if(count>=1){
                player.transform.position=targetPos;
                break;
            }
            yield return null;
        }



       

    }
}
