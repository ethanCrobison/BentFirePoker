﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureUIScript : MonoBehaviour {

	private int TreasureCount;

	void Start() {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.EventTreasureCollected += IncrementTreasure;
		eventBus.EventNewMinion += DecrementTreasure;
		TreasureCount = 10;
		UpdateTreasureCount ();
	}

	private void IncrementTreasure() {
		TreasureCount ++;
		UpdateTreasureCount ();
	}

	private void DecrementTreasure() {
		TreasureCount--;
		UpdateTreasureCount ();
	}

	private void UpdateTreasureCount() {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Treasure: {0}", TreasureCount);
	}
}
