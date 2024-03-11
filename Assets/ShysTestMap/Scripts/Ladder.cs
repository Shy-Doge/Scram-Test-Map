using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scram;

public class Ladder : MonoBehaviour
{
	void OnTriggerStay(Collider other)
	{
		Player component = other.GetComponent<Player>();
		if (component != null)
		{
			component.transform.position += this.transform.up * Time.fixedDeltaTime;
		}
	}
}
