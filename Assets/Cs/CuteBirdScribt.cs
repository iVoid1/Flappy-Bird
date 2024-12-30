// using Unity.VisualScripting;
// using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class CuteBirdScribt : MonoBehaviour
{
    public float FlapStrength;
    private Rigidbody2D rb;
    public Logicmangar Logic;
    private bool canPlay = true;
    private bool FirstJump = true;
    private float secret;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmangar>();
        secret = Logic.pipeSpeed;
    }

    void Update()
    { 
        if (FirstJump)
            {
                rb.linearVelocity = Vector2.up * FlapStrength;
                Logic.pipeSpeed = secret;
                FirstJump = false;
            }


        if (Input.GetKeyDown(KeyCode.Space) && canPlay)
        {
            rb.linearVelocity = Vector2.up * FlapStrength;
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Top")){
            return;
        }
        Logic.GameOverScreen();
        canPlay = false;
        StartCoroutine(SlowDownPipeSpeed());

    IEnumerator SlowDownPipeSpeed()
    {
        while (Logic.pipeSpeed > 0)
        {
            Logic.pipeSpeed -= Time.deltaTime * 5;
            yield return null;
        }
    
    }
    }}
