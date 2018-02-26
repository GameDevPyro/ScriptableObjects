using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject {
	public Sprite artwork;

	[Header("Game setup values")]
	[Range(0,20)]
	public int setupVictoryPoints = 0;
	[Range(0,12)]
	public int setupLifePoints = 10;
}