using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;

public class ItemsSpawner : MonoBehaviour
{
    /*
     * 
     *      THIS WILL NEED A MODDED BOLT.USER.DLL
     * 
     */

    public enum Item { Prize_1, Prize_2, Prize_3, Prize_4, Prize_5, Prize_6, Prize_7, Prize_8, Campaign_Prize_1 };
    public Item ItemsType = Item.Prize_1;

    void Start()
    {
        GameStarted();
    }


    void GameStarted()
    {
        if (BoltNetwork.isServer)
        {
            BoltEntity ent = null;
            switch (ItemsType)
            {
                /*case Item.Egg1:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_1);
                    break;
                case Item.Egg2:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_2);
                    break;
                case Item.Egg3:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_3);
                    break;
                case Item.Egg4:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_4);
                    break;
                case Item.Egg5:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_5);
                    break;
                case Item.Egg6:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_6);
                    break;
                case Item.Egg7:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_7);
                    break;
                case Item.Egg8:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_8);
                    break;
                case Item.Egg9:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_9);
                    break;
                case Item.Egg10:
                    ent = BoltNetwork.Instantiate(BoltPrefabs.Egg_10);
                    break;*/
                case Item.Prize_1:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_1, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_2:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_2, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_3:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_3, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_4:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_4, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_5:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_5, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_6:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_6, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_7:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_7, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Prize_8:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Prize_8, null, this.transform.position, this.transform.rotation, false);
                    break;
                case Item.Campaign_Prize_1:
                    ent = BoltPooler.Instance.Instantiate(BoltPrefabs.Campaign_Prize_1, null, this.transform.position, this.transform.rotation, false);
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
        Gizmos.color = Color.red;

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