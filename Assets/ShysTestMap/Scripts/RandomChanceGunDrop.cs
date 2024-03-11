using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChanceGunDrop : MonoBehaviour {


    void Start()
    {
        GameStarted();
    }

    void OnDisable()
    {
        //BattleRoyaleGamemode.GameStarted.RemoveListener(GameStarted);
    }

    void GameStarted()
    {
        if (BoltNetwork.isServer)
        {
            int random = Random.Range(0, 20);
            BoltEntity ent = null;
            if (random == 0)
                ent = BoltNetwork.Instantiate(BoltPrefabs.AA12_Pickup, null);
            else if (random == 1)
                ent = BoltNetwork.Instantiate(BoltPrefabs.AK47_Pickup, null);
            else if (random == 2)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Glock_Pickup, null);
            else if (random == 3)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Deagle_Pickup, null);
            else if (random == 4)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Uzi_Pickup, null);
            else if (random == 5)
                ent = BoltNetwork.Instantiate(BoltPrefabs.SCAR_Pickup, null);
            else if (random == 6)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Peanut_Bag_Pickup, null);
            else if (random == 7)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Peanut_Jar_Pickup, null);
            else if (random == 8)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Colt_Python_Pickup, null);
            else if (random == 9)
                ent = BoltNetwork.Instantiate(BoltPrefabs.M4A1_Pickup, null);
            else if (random == 10)
                ent = BoltNetwork.Instantiate(BoltPrefabs.M16A1_Pickup, null);
            else if (random == 11)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Kriss_Vector_Pickup, null);
            else if (random == 12)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Grenade_Pickup, null);
            else if (random == 13)
                ent = BoltNetwork.Instantiate(BoltPrefabs.Famas_Pickup, null);
            else
                ent = null;

            if (ent != null)
            {
                ent.transform.position = transform.position;
                ent.GetComponent<Rigidbody>().AddExplosionForce(10f, this.transform.position - Vector3.up, 10f, 1f, ForceMode.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        int iterations = 10;
        float angle = 0;
        Vector3 lastPos = transform.position + new Vector3(Mathf.Sin(0), 0, Mathf.Cos(0));
        for (int i = 0; i < iterations + 1; i++)
        {
            Vector3 curPos = transform.position + new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
            Gizmos.DrawLine(lastPos, curPos);
            lastPos = curPos;
            angle += (360f / iterations);
        }
    }
}
