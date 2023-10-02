using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    private bool isProjectileDestroyed = false;
    public bool IsProjectileDestroyed { get => isProjectileDestroyed; }
    private bool isWin = false;
    public bool IsWin { get => isWin; }

    void Start()
    {
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 20f)
        {
            animator.SetBool("isPlayerClose", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            isProjectileDestroyed = true;
        }

        if(other.gameObject.tag == "Player")
        {
            isWin = true;
        }
    }
}
