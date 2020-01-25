using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public string [] mode = {"opening", "prologue", "intro", "inscene", "outtro","linkscene","ending"};
     private static GameManager s_manager;
     public string mode;
     public static GameManager GetInstance(){
         return s_manager;
     }

    private void Awake(){
        s_manager=this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
