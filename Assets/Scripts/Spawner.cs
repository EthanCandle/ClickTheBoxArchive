using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 2f, spawnRateLimit = 0.75f, spawnRateDecrease = 0.1f;
    
    public PlayerManagment pm;


    // Start is called before the first frame update
    void Start()
    {
        pm.isGameRunning = true;
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        
       while (pm.isGameRunning) 
       {
           
            yield return new WaitForSeconds(spawnRate);
            //int index = Random.Range(0, targets.Count);
            int index = Random.Range(0, 101);
            int target = 1;
            int targetTwo = 1;

            if(index < 80)
            {
                target = 0;
                // spawn good target if rng = 80 or lower 80%
            }
            else
            {
                target = 1;
                // spawn good target if rng = 81 or higher 20%
            }

            //Instantiate(targets[index]);
            Instantiate(targets[target]);
           

            int another = Random.Range(0, 101);
            if(another <= 20)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
                targetTwo = Random.Range(0, 2);
                Instantiate(targets[targetTwo]);
                Debug.Log("Spawned Second Target");
            }

            if (spawnRate > spawnRateLimit)
            {
                spawnRate -= spawnRateDecrease;
            }
            
       }
    }


}
