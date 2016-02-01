using UnityEngine;
using System.Collections;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;

	private float minX = -5.0F;
	private float maxX =  5.0F;
	private float minY = -5.0F;
	private float maxY =  5.0F;

	private bool direction = true;

	void Update () {
		var posX = this.transform.localPosition.x;
		if (posX < minX) {
			direction = true;
		} else if (posX > maxX) {
			direction = false;
		}

		if (direction) {
			this.transform.Translate (speed * Time.deltaTime, 0, 0);
		} else {
			this.transform.Translate (-1 * speed * Time.deltaTime, 0, 0);

		}
	}
}
