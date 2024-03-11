using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Scram;
using System;

public class Monke : MonoBehaviour
{

    BoltEntity ent = null;

    List<BoltEntity> allPlayers = new List<BoltEntity>();

    float distance;

    float closerDistance;
    int closerPlayer = 0;

    Component controller;

    public BoltEntity[] AllPlayers
    {
        get
        {
            BoltEntity[] arr = new BoltEntity[] { };
            allPlayers.CopyTo(arr);
            return arr;
        }
    }

    void UpdatePlayers()
    {
        allPlayers = FindObjectsOfType<BoltEntity>().Where(x => x.isAttached && x.StateIs(typeof(IPlayerState))).ToList();
    }

    // Use this for initialization
    void Start()
    {

        if (BoltNetwork.isServer)
        {
            InvokeRepeating("UpdatePlayers", 1, 1);


            ent = BoltNetwork.Instantiate(BoltPrefabs.MonkeyPrefab);
            //ent.AddComponent<MonkeController>();
            ent.transform.position = this.transform.position;
            ent.gameObject.AddComponent<MonkeController>();
            //controller = ent.gameObject.GetComponent("MonkeController");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        closerDistance = float.MaxValue;

        for (int i = 0; i < allPlayers.Count; i++)
        {
            try
            {
                distance = Mathf.Round(Vector3.Distance(allPlayers[i].transform.position, ent.transform.position) * 100.0f);
            }
            catch (Exception e)
            {
                // recover from exception
                Debug.Log("my log");
            }
            if (closerDistance > distance)
            {
                closerDistance = distance;
                closerPlayer = i;
            }
            ent.transform.LookAt(allPlayers[closerPlayer].transform);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 middlePos = transform.position + Vector3.up * 0.7684905f;
        Gizmos.DrawWireCube(middlePos, new Vector3(0.6156186f, 1.536981f, 0.6156186f));
        Gizmos.DrawLine(middlePos, middlePos + (transform.forward * 0.25f));
        Gizmos.DrawLine(middlePos + (transform.forward * 0.10f) + (transform.right * 0.10f), middlePos + (transform.forward * 0.25f));
        Gizmos.DrawLine(middlePos + (transform.forward * 0.10f) + (transform.right * -0.10f), middlePos + (transform.forward * 0.25f));
    }
}

