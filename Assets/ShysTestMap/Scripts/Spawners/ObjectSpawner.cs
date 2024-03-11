using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;

public class ObjectSpawner : MonoBehaviour
{
    /*
     * 
     *      THIS WILL NEED A MODDED BOLT.USER.DLL
     * 
     */

    public enum Objects { Ammo_Box, Ammo_Box_1_, Turret, Laser_Turret, Ball, Coldsack_Door, Crate, Helicopter, Plank, Grenade_Projectile, M32_Projectile, RPG7_Projectile, Creature, MonkeyPrefab, Player_Info };
    public Objects ObjectsType = Objects.Turret;

    void Start()
    {
        GameStarted();
    }


    void GameStarted()
    {
        if (BoltNetwork.isServer)
        {
            BoltEntity ent = null;
            switch (ObjectsType)
            {
                case Objects.Turret:
                    BoltPooler.Instance.Instantiate(BoltPrefabs.Turret, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Laser_Turret:
                    BoltPooler.Instance.Instantiate(BoltPrefabs.Laser_Turret, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Coldsack_Door:
                    BoltPooler.Instance.Instantiate(BoltPrefabs.Coldsack_Door, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Ammo_Box:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Ammo_Box, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Ammo_Box_1_:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Ammo_Box_1_, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Player_Info:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Player_Info, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Plank:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Plank, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.MonkeyPrefab:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.MonkeyPrefab, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Creature:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Creature, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Helicopter:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Helicopter, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Ball:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Ball, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Crate:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Crate, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.Grenade_Projectile:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Grenade_Projectile, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.M32_Projectile:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M32_Projectile, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Objects.RPG7_Projectile:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.RPG7_Projectile, null, this.transform.position, this.transform.rotation, false);
                    break;

                default:
                    ent = null;
                    break;
            }

            //ent.transform.position = transform.position;

            if (ent != null)
            {
                //ent.transform.position = transform.position;
                ent.GetComponent<Rigidbody>().AddExplosionForce(10f, this.transform.position - Vector3.up, 10f, 1f, ForceMode.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

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
