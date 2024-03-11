using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;

public class PickupSpawner : MonoBehaviour
{
    /*
     * 
     *      THIS WILL NEED A MODDED BOLT.USER.DLL
     * 
     */

    public enum Pickups { AA12, AK47, AKM, AR15, AUG, Barrett, Colt_Python, Deagle, Famas, Glock, K2, Kriss_Vector, L96, M14, M16A1, M1911, M249, M32, M4A1, M60, MAC10, MP5, P90, RPG7, SCAR, SPAS12, Thompson, Uzi, DC15S, E5, Lightsaber, Shield, Grenade, Peanut_Bag, Peanut_Jar, Plank_Hammer };
    public Pickups PickupsType = Pickups.AK47;

    void Start()
    {
        GameStarted();
    }


    void GameStarted()
    {
        if (BoltNetwork.isServer)
        {
            BoltEntity ent = null;
            switch (PickupsType)
            {
                case Pickups.AA12:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.AA12_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.AK47:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.AK47_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.AKM:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.AKM_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.AR15:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.AR15_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Famas:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Famas_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.K2:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.K2_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.L96:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.L96_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M16A1:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M16A1_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M60:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M60_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.SPAS12:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.SPAS12_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Thompson:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Thompson_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Uzi:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Uzi_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;   
                case Pickups.Glock:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Glock_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Deagle:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Deagle_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.SCAR:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.SCAR_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M4A1:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M4A1_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Kriss_Vector:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Kriss_Vector_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.AUG:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.AUG_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Grenade:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Grenade_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Peanut_Bag:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Peanut_Bag_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Peanut_Jar:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Peanut_Jar_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Barrett:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Barrett_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M14:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M14_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.MAC10:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.MAC10_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.MP5:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.MP5_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.P90:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.P90_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.RPG7:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.RPG7_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Plank_Hammer:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Plank_Hammer_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M32:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M32_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M249:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M249_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Colt_Python:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Colt_Python_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Shield:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Shield_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.M1911:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.M1911_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.DC15S:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.DC15S_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.E5:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.E5_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Pickups.Lightsaber:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Lightsaber_Pickup, null, this.transform.position, this.transform.rotation, false);
                    break;


                default:
                    ent = null;
                    break;
            }

            //ent.transform.position = transform.position;

            if (ent != null)
            {
                ent.transform.position = transform.position;
                ent.GetComponent<Rigidbody>().AddExplosionForce(10f, this.transform.position - Vector3.up, 10f, 1f, ForceMode.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

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
