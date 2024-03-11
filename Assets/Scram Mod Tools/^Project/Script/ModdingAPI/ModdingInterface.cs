using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdingInterface : MonoBehaviour {

	public static void RunCoroutine(IEnumerator<float> func) {}

    public static float WaitUntilTrue(System.Func<bool> evalFunc)
    {
        return 0f;
    }
}
