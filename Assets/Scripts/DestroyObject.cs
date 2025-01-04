using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public PlayerManagment pm;
    public bool bad;
    public int scoreChange;
    public Rigidbody rb;
    public float minSpeed = 12, maxSpeed = 16, maxTorque = 10, xRange, ySpawnPos;
    public GameObject leftSpawn, rightSpawn, upSpawn;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerManagment>();
        leftSpawn = GameObject.FindGameObjectWithTag("LeftSpawn");
        rightSpawn = GameObject.FindGameObjectWithTag("RightSpawn");
        upSpawn = GameObject.FindGameObjectWithTag("UpSpawn");
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (pm.isGameRunning)
        {
            pm.score += scoreChange;
            pm.ScoreChanged();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (pm.isGameRunning && !bad)
        {
            pm.isHurt = true;
           
        }
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(leftSpawn.transform.position.x, rightSpawn.transform.position.x), upSpawn.transform.position.y);
    }




}
