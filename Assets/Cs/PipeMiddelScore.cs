// using System;
// using Unity.Mathematics;
// using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddelScore : MonoBehaviour
{
    private Logicmangar Logic;
    private PipemoveScript PipMove;
    private PipeSpawner pipeSpawner;    
    public int scoreAdd;
    // public bool lowRate = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmangar>();
        PipMove = GameObject.FindGameObjectWithTag("PipeM").GetComponent<PipemoveScript>();
        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawner>();
    }



    private void OnTriggerEnter2D(Collider2D  collision)
    
    {
       if ((float) pipeSpawner.spawnRate > 3.5 && Logic.playerScore > 25 * Logic.multiplyer)
            {pipeSpawner.spawnRate -= 0.1f;}

       if (Logic.playerScore > 25 * Logic.multiplyer)
       {
           Logic.multiplyer += 1;
           scoreAdd *= Logic.multiplyer;
           Logic.pipeSpeed += Logic.multiplyer * 2;
       }


       if (collision.gameObject.layer == 3)
           {
               Logic.addScore(scoreAdd);
           }  
    }
}
