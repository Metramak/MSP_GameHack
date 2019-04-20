﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    private Vector3 newPointForPlayer;
    public NavMeshAgent agent;
    private GameObject clone;
    public GameObject spawnObject;
    public bool patrule;
    private bool checkSpawnPoints;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        patrule = true;
        checkSpawnPoints = true;
    }

    void Update()
    {
        if (patrule == true)
        {
            if (checkSpawnPoints == true)
            {
                checkSpawnPoints = false;
                spawnPoints();
            }
            if (Vector3.Distance(transform.position, clone.transform.position) <= 1.5f)
            {
                Destroy(clone);
                checkSpawnPoints = true;
            }
        }
        agent.SetDestination(newPointForPlayer);
    }
    void spawnPoints()
    {
        Vector3 truePos = transform.position;
        NavMeshHit hit;
        do
        {
            float xcor = Random.Range(-20f, 20f);
            float ycor = 0.125f;
            float zcor = Random.Range(-20f, 20f);
            truePos = new Vector3(startPos.x + xcor, startPos.y + ycor, startPos.z + zcor);
        }
        while (NavMesh.SamplePosition(truePos, out hit, 1f, NavMesh.AllAreas) == false);
        clone = Instantiate(spawnObject, truePos, Quaternion.identity);
        newPointForPlayer = clone.transform.position;
    }
}
