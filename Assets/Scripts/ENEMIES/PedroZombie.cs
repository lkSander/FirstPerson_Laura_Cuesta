using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PedroZombie : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        player=GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(player.gameObject.transform.position);
    }
}
