using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Material materialAfterTrigger;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            this.gameObject.GetComponent<MeshRenderer>().material = materialAfterTrigger;
            Invoke("DestroyAfterDelay", 1.5f);
        }

        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().IsPlayerDestroyed = true;
        }
    }

    private void DestroyAfterDelay()
    {
        Destroy(this.gameObject);
    }
}
