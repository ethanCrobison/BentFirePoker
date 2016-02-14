using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	private int _OrdinaryMinionCount = 0;

	void Start () {
		var manager = GameObject.Find ("MinionManager");
		var mm = manager.GetComponent<MinionManager> ();
		mm.NewMinion += OnMinionSpawn;

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
