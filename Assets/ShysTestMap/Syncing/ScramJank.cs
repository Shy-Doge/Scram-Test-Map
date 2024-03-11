using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class ScramJank : MonoBehaviour {

    static ScramJank instance;
    List<IBotState> entities = new List<IBotState>();

    public static void SetNetworkBool(string Identifier, bool value) { instance.SetBool(Identifier, value); }
    public static void SetNetworkFloat(string Identifier, float value) { instance.SetFloat(Identifier, value); }
    public static void SetNetworkString(string Identifier, string value) { instance.SetString(Identifier, value); }
    public static void SetNetworkVector3(string Identifier, Vector3 value) { instance.SetVector3(Identifier, value); }
    public static bool GetNetworkBool(string Identifier) { return instance.GetBool(Identifier); }
    public static float GetNetworkFloat(string Identifier) { return instance.GetFloat(Identifier); }
    public static string GetNetworkString(string Identifier) { return instance.GetString(Identifier); }
    public static Vector3 GetNetworkVector3(string Identifier) { return instance.GetVector3(Identifier); }

    void Awake()
    {
        instance = this;
    }

	void SetBool(string Identifier, bool value)
    {
        if (!BoltNetwork.isServer)
            return;

        IBotState ent = entities.Find(x => x.botName == "Network-Variable-" + Identifier);

        if(ent == null)
        {
            BoltEntity newEnt = BoltNetwork.Instantiate(BoltPrefabs.MonkeyPrefab, new Vector3(0, -1024, 0), Quaternion.identity);
            newEnt.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            ent = newEnt.GetState<IBotState>();
            ent.botName = "Network-Variable-" + Identifier;
            entities.Add(ent);
        }

        ent.isDead = value;
    }

    public bool GetBool(string Identifier)
    {
        IBotState ent = entities.Find(x => x.botName == "Network-Variable-" + Identifier);

        if(ent == null)
        {
            BoltEntity foundEntity = FindObjectsOfType<BoltEntity>().Where(x => x.StateIs<IBotState>() && x.GetState<IBotState>().botName == "Network-Variable-" + Identifier).First();

            if (foundEntity == null)
                return false;

            ent = foundEntity.GetState<IBotState>();
            entities.Add(ent);
        }

        return ent.isDead;
    }

    public void SetFloat(string Identifier, float value)
    {
        if (!BoltNetwork.isServer)
            return;

        IBotState ent = entities.Find(x => x.botName.StartsWith("Network-Variable-" + Identifier));

        if (ent == null)
        {
            BoltEntity newEnt = BoltNetwork.Instantiate(BoltPrefabs.MonkeyPrefab, new Vector3(0, -1024, 0), Quaternion.identity);
            newEnt.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            ent = newEnt.GetState<IBotState>();
            entities.Add(ent);
        }

        ent.botName = "Network-Variable-" + Identifier + value;
    }

    public float GetFloat(string Identifier)
    {
        IBotState ent = entities.Find(x => x.botName.StartsWith("Network-Variable-" + Identifier));

        if (ent == null)
        {
            BoltEntity foundEntity = FindObjectsOfType<BoltEntity>().Where(x => x.StateIs<IBotState>() && x.GetState<IBotState>().botName.StartsWith("Network-Variable-" + Identifier)).First();

            if (foundEntity == null)
                return 0;

            ent = foundEntity.GetState<IBotState>();
            entities.Add(ent);
        }

        return float.Parse(ent.botName.Replace("Network-Variable-" + Identifier, ""));
    }

    public void SetString(string Identifier, string value)
    {
        if (!BoltNetwork.isServer)
            return;

        IBotState ent = entities.Find(x => x.botName.StartsWith("Network-Variable-" + Identifier));

        if (ent == null)
        {
            BoltEntity newEnt = BoltNetwork.Instantiate(BoltPrefabs.MonkeyPrefab, new Vector3(0, -1024, 0), Quaternion.identity);
            newEnt.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            ent = newEnt.GetState<IBotState>();
            entities.Add(ent);
        }

        ent.botName = "Network-Variable-" + Identifier + value;
    }

    public string GetString(string Identifier)
    {
        IBotState ent = entities.Find(x => x.botName.StartsWith("Network-Variable-" + Identifier));

        if (ent == null)
        {
            BoltEntity foundEntity = FindObjectsOfType<BoltEntity>().Where(x => x.StateIs<IBotState>() && x.GetState<IBotState>().botName.StartsWith("Network-Variable-" + Identifier)).First();

            if (foundEntity == null)
                return "";

            ent = foundEntity.GetState<IBotState>();
            entities.Add(ent);
        }

        return ent.botName.Replace("Network-Variable-" + Identifier, "");
    }

    public void SetVector3(string Identifier, Vector3 value)
    {
        SetFloat(Identifier + "X", value.x);
        SetFloat(Identifier + "Y", value.y);
        SetFloat(Identifier + "Z", value.z);
    }

    public Vector3 GetVector3(string Identifier)
    {
        return new Vector3(GetFloat(Identifier + "X"), GetFloat(Identifier + "Y"), GetFloat(Identifier + "Z"));
    }
}
