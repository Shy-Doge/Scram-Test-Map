using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public enum Powerup { AK47, AR15, Famas, K2, L96, M16A1, M60, SPAS12, Thompson, Uzi };
    public Powerup PowerupType = Powerup.AK47;

    void Start()
    {
        GameStarted();
    }


    void GameStarted()
    {
        if (BoltNetwork.isServer)
        {
            BoltEntity ent = null;
            switch (PowerupType)
            {
                case Powerup.AK47:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.AK47_Powerup);
                    break;
                case Powerup.AR15:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.AR15_Powerup);
                    break;
                case Powerup.Famas:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Famas_Powerup);
                    break;
                case Powerup.K2:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.K2_Powerup);
                    break;
                case Powerup.L96:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.L96_Powerup);
                    break;
                case Powerup.M16A1:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.M16A1_Powerup);
                    break;
                case Powerup.M60:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.M60_Powerup);
                    break;
                case Powerup.SPAS12:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.SPAS12_Powerup);
                    break;
                case Powerup.Thompson:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Thompson_Powerup);
                    break;
                case Powerup.Uzi:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Uzi_Powerup);
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
        Gizmos.color = Color.yellow;

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
