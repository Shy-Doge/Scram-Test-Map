using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Scram;

public class MonkeController : MonoBehaviour {

	NavMeshAgent monke;
	Transform player;

	void Awake()
	{
		// references
		Debug.Log("test1");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Debug.Log("test2");
		monke.GetComponent<NavMeshAgent>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		monke.SetDestination(player.position);
		//transform.LookAt(player);
		
	}
}
