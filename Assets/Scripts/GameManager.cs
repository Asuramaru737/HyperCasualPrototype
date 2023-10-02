using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject goalObj;
    private GameObject projectileClon;
    public GameObject player;

    private PlayerController playerController; 
    private float projectileSpeed = 15f;
    private Vector3 lossCondition = new(1.5f, 1.5f, 1.5f);
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            projectileClon = playerController.GetProjectile;
        }

        if(projectileClon != null)
        projectileClon.transform.Translate(0, 0, projectileSpeed * Time.deltaTime);

        if(goalObj.GetComponent<GoalController>().IsWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (playerController.IsPlayerDestroyed || playerController.transform.localScale.magnitude<lossCondition.magnitude)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
