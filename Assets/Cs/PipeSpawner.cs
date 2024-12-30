using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    private Logicmangar Logic;
    public float timer;
    public float spawnRate;
    public float pipeOffsit;
    public float lowestTime;
    public float highestTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipes();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmangar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            
        }
        else 
        {
            if (Logic.pipeSpeed > 0)
            {
                SpawnPipes();
            }

            timer = Random.Range(lowestTime, highestTime);
        }
        
    }
    void SpawnPipes()
    {
        float highestPoint = transform.position.y + pipeOffsit;
        float lowestPoint = transform.position.y - pipeOffsit;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
