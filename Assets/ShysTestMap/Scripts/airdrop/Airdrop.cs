using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;
using Bolt;
using UnityEngine.AI;
using System;

public class Airdrop : MonoBehaviour, IDamageable
{
    public int maxHp = 1000;
    [HideInInspector]
    public int hp;
    [HideInInspector]
    public bool ded;
    // [HideInInspector]
    // public List<BoltPrefabs> spawnList = new List<BoltPrefabs>();

    void Start()
    {
        hp = maxHp;
        ded = true;
        if (BoltNetwork.isServer)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void IDamageable.Die(Vector3 direction, string enemyName, PlayerConnection enemyConnection)
    {
        if (!BoltNetwork.isServer)
        {
            return;
        }
        if (!ded)
        {
            ded = true;
            BoltEntity ent = null;
            int rng = UnityEngine.Random.Range(0, 3);
            if (rng == 0)
            {
                ent = BoltNetwork.Instantiate(BoltPrefabs.L96_Pickup);
            }
            else if (rng == 1)
            {
                ent = BoltNetwork.Instantiate(BoltPrefabs.AR15_Pickup);
            }
            else if (rng == 2)
            {
                ent = BoltNetwork.Instantiate(BoltPrefabs.Barrett_Pickup);
            }
            else if (rng == 3)
            {
                ent = BoltNetwork.Instantiate(BoltPrefabs.AKM_Pickup);
            }
            else
            {
                ent = BoltNetwork.Instantiate(BoltPrefabs.Peanut_Bag_Pickup);
            }
            ent.transform.position = this.transform.position;
            ent.GetComponent<Rigidbody>().AddExplosionForce(10f, this.transform.position - direction, 10f, 1f, ForceMode.Impulse);
        }
        transform.position = Vector3.down * 1000f;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void IDamageable.TakeDamage(int damage, Vector3 direction, string enemyName, PlayerConnection enemyConnection, bool isFall)
    {
        if (!BoltNetwork.isServer)
        {
            return;
        }
        hp -= damage;
        if (hp <= 0)
        {
            ((IDamageable)this).Die(direction, enemyName, enemyConnection);
        }
    }

    public void SpawnAt(Vector3 pos)
    {
        if (!BoltNetwork.isServer)
        {
            return;
        }
        hp = maxHp;
        ded = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.position = pos;
    }

    public void DeSpawn()
    {
        if (!BoltNetwork.isServer)
        {
            return;
        }
        ded = true;
        transform.position = Vector3.down * 1000f;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
