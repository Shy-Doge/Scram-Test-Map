using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//using Scram;

public class HeliMovement : MonoBehaviour
{

    /*
     * 
     *      THIS WILL NEED A MODDED BOLT.USER.DLL
     * 
     */

    public Transform helicopterStart;
    public Transform helicopterEnd;

    BoltEntity heli;
    // Use this for initialization
    void Start()
    {
        
    }

    public float speed;
    void Update()
    {
        
    }

    IEnumerator destroyHeli()
    {
        yield return new WaitForSeconds(5);
        if (heli != null)
            BoltNetwork.Destroy(heli);
    }

    void FixedUpdate()
    {

        if (BoltNetwork.isServer)
        {
            if (heli != null)
            {
                heli.transform.Translate(Vector3.forward * 15 * Time.fixedDeltaTime, Space.Self);
                //float step = speed * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, helicopterEnd.transform.position, step);

                if (Vector3.Distance(heli.transform.position, helicopterEnd.position) < 5f)
                {
                    destroyHeli();
                }
            }


            if (heli == null)
                heli = BoltNetwork.Instantiate(BoltPrefabs.Helicopter);


            heli.transform.position = helicopterStart.position;
            heli.transform.LookAt(helicopterEnd);

        }
    }
}