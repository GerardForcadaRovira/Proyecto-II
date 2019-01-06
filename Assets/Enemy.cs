using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Elemento
{
    public class Enemy : MonoBehaviour
    {

        public float lookRadius = 1f;
        Transform target;
        NavMeshAgent agent;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            float dist = Vector3.Distance(target.position, transform.position);
            
            if (dist <= lookRadius)
                agent.SetDestination(target.position);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

    }
}
