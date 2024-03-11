using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableEvac : MonoBehaviour {
	[SerializeField]
	private GameObject Scripts;
	//[SerializeField]
	//private GameObject Lounge;

	[SerializeField]
	public string m_Scene;
	// Use this for initialization
	void Start () {
		GameObject.Find("Script").transform.Find("Game Mode").gameObject.SetActive(false);
		GameObject.Find("Script").transform.Find("Lounge").gameObject.SetActive(false);

		GameObject GameMode = GameObject.Find("Script").transform.Find("Game Mode").gameObject;
		GameObject Lounge = GameObject.Find("Script").transform.Find("Lounge").gameObject;

		Destroy(GameMode);
		Destroy(Lounge);

		SceneManager.MoveGameObjectToScene(Scripts, SceneManager.GetSceneByName(m_Scene));
		//SceneManager.MoveGameObjectToScene(Lounge, SceneManager.GetSceneByName(m_Scene));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
