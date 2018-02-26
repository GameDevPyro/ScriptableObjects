using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MonsterDisplay : MonoBehaviour {
	[Tooltip("Drag the Monster here")]
	public Monster monster;
	[Tooltip("Drag the MonsterBoard here")]
	public Image artworkImage;

	public GameObject RefChooseMonster;

	void Start () {
		DisplayMonster ();
	}

	public void DisplayMonster() {
		artworkImage.sprite = monster.artwork;
		artworkImage.SetNativeSize ();
	}
}
