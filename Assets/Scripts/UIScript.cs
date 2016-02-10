using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	private int _OrdinaryMinionCount = 0;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		ps.SpawnMinion += OnMinionSpawn;

		UpdateMinionCount ();
	}

	private void OnMinionSpawn() {
		_OrdinaryMinionCount += 1;
		UpdateMinionCount ();
	}

	private void UpdateMinionCount () {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Plain Count: {0}", _OrdinaryMinionCount);

	}

}
