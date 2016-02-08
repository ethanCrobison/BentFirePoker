using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	private int _MinionCount = 0;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		ps.SpawnMinion += OnMinionSpawn;

		UpdateMinionCount ();
	}

	private void OnMinionSpawn() {
		_MinionCount += 1;
		UpdateMinionCount ();
	}

	private void UpdateMinionCount () {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Minion Count: {0}", _MinionCount);
	}

}
