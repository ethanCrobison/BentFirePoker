using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DodgeUIScript : MonoBehaviour {

	private PlayerScript player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript>();
	}

	void Update () {
		UpdateDodgeVal ();
	}

	private void UpdateDodgeVal() {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Dodge Cooldown: {0:F1}", player.GetTimeSinceLastDodge());
	}
}
