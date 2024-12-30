// using Unity.VisualScripting;
// using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System.Collections;

public class CuteBirdScribt : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Logicmangar Logic;
    public float FlapStrengh;
    public bool canPlay = true;
    private bool FristJump = true;
    private float secrt;

    void Start()
    {
        Logic.MainMenu.gameObject.SetActive(true);
        secrt = Logic.pipeSpeed;
    }

    void Update()
    {
        if (Logic.MainMenu.IsActive())
        {
            transform.position = Vector3.zero;
            Logic.pipeSpeed = 0;
        }

        else
        {   if (FristJump)
            {
                myRigidbody2D.linearVelocity = Vector2.up * FlapStrengh;
                Logic.pipeSpeed = secrt;
                FristJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPlay && !Logic.MainMenu.IsActive())
        {
            myRigidbody2D.linearVelocity = Vector2.up * FlapStrengh;
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.GameOverScreen();
        canPlay = false;
        StartCoroutine(SlowDownPipeSpeed()); // تشغيل Coroutine
    }

    IEnumerator SlowDownPipeSpeed()
    {
        while (Logic.pipeSpeed > 0) // طالما السرعة أكبر من 0
        {
            Logic.pipeSpeed -= Time.deltaTime * 5; // قلل السرعة تدريجيًا
            yield return null; // انتظر الإطار التالي قبل المتابعة
        }
    
    }
}
