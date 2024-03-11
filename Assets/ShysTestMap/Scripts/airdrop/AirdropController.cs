using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;
using Bolt;
using UnityEngine.AI;
using System;

public class AirdropController : MonoBehaviour
{
    public float maxCountdown = 100f;
    [HideInInspector]
    public float countdown = 0f;
    public GameObject airdropGameobject;
    public GameObject[] spawns;
    
    void Start()
    {
        if (BoltNetwork.isServer)
            GameStarted();
    }

    void OnDisable()
    {
        if (BoltNetwork.isServer)
            return;
    }

    void GameStarted()
    {
        airdropGameobject.GetComponent<Airdrop>().DeSpawn();
    }

    void Update()
    {
        if (!BoltNetwork.isServer)
        {
            airdropGameobject.transform.position = ScramJank.GetNetworkVector3("airdropbagpos");
            airdropGameobject.transform.eulerAngles = ScramJank.GetNetworkVector3("airdropbagrot");
            return;
        }
        ScramJank.SetNetworkVector3("airdropbagpos", airdropGameobject.transform.position);
        ScramJank.SetNetworkVector3("airdropbagrot", airdropGameobject.transform.eulerAngles);
        if (!BoltNetwork.isServer)
        {
            countdown = maxCountdown;
            return;
        }
        if (!airdropGameobject.GetComponent<Airdrop>().ded && airdropGameobject.transform.position.y <= 1000f)
        {
            countdown = maxCountdown;
            return;
        }
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            countdown = maxCountdown;
            BoltGlobalEvent.SendObjectiveEvent("airdrop inbound!", "Alert", Color.red);
            GameObject spawn = spawns[UnityEngine.Random.Range(0, spawns.Length)];
            airdropGameobject.GetComponent<Airdrop>().SpawnAt(spawn.transform.position);
        }
    }
}
