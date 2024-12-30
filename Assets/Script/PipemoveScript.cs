using UnityEngine;
// using System.Collections;
public class PipemoveScript : MonoBehaviour
{
    private Logicmangar Logic;
    public float deadZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmangar>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + (Vector3.left * Logic.pipeSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone || Logic.pipeSpeed <= 0)
        {
            Destroy(gameObject);
        }
    }

}
