using UnityEngine;

public class Instructions : MonoBehaviour {
	public GameObject InstructionsContainer;

	public void Play() {
		InstructionsContainer.SetActive (false);
	}
}