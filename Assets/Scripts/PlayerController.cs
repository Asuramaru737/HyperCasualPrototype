using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private GameObject clone;
    public GameObject goalObj;
    private Animator animator;
    private float playerSpeed = 10f;
    private bool isProjectileCreated = false;
    private bool isCharged = false;
    private bool isPlayerDestroyed = false;
    public bool IsPlayerDestroyed 
    {
        get => isPlayerDestroyed; 
        set => isPlayerDestroyed = value;
    }

    public GameObject GetProjectile 
    {
        get => clone;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CreateProjectile();
        ChargeProjectile();
        if(Input.GetMouseButtonUp(0))
        {
            isCharged = true;
        }

        if(goalObj.GetComponent<GoalController>().IsProjectileDestroyed)
        {
            animator.SetBool("isMoving", true);
            transform.Translate(0, 0, playerSpeed * Time.deltaTime);
        }
    }

    void CreateProjectile()
    {
        if(Input.GetMouseButton(0) && !isProjectileCreated)
        {
           clone = Instantiate(projectile, new Vector3(0f, 2.5f, 4f), Quaternion.identity);
           isProjectileCreated = true;
        }
    }

    void ChargeProjectile()
    {
        if(Input.GetMouseButton(0) && !isCharged)
        {
            clone.transform.localScale = Vector3.Lerp(clone.transform.localScale, new Vector3(4f, 4f, 4f), 1f*Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 1f*Time.deltaTime);
        }
    }
        
}
