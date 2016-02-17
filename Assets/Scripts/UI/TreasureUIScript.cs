using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureUIScript : MonoBehaviour {

	private int TreasureCount;

	void Start() {
		TreasureCount = 10;
		UpdateTreasureCount ();
	}

	public void IncrementTreasure() {
		TreasureCount += 1;
		UpdateTreasureCount ();
	}

	private void UpdateTreasureCount() {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Treasure: {0}", TreasureCount);
	}
}
