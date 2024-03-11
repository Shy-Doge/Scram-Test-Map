using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;

public class BreakableObject : MonoBehaviour, IDamageable {

    public int maxHp = 1000;
    [HideInInspector]
    public int hp;
    [HideInInspector]
    public bool ded;

    void Start()
    {
        hp = maxHp;
        ded = true;
        /*if (BoltNetwork.isServer)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }*/
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
            /*
             *  If killed you can make it do something here...
            */
        }
        transform.position = Vector3.down * 1000f;
        //GetComponent<Rigidbody>().isKinematic = true;
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
        //GetComponent<Rigidbody>().isKinematic = false;
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
        //GetComponent<Rigidbody>().isKinematic = true;
    }

}
