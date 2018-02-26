using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MonsterManager : MonoBehaviour {
	#region Values
	[Header("Victory Points")]
	[Tooltip("Reference to the Victory Points wheel")]
	public GameObject RefVPWheel;
	int CurrentVPTotal;
	[Tooltip("The new Victory Points total")][Range(0,20)]
	public int NewVPTotal;
	float VPAngleToTurnTo;
	[Tooltip("Drag Victory Points Slider here")]
	public Slider VPSlider;
	[Tooltip("Drag Victory Points Wheel text")]
	public Text VPWheelText;
	
	[Header("Life Points")]
	[Tooltip("Reference to the Life Points Wheel")]
	public GameObject RefLPWheel;
	int CurrentLPTotal;
	[Tooltip("The new Life Points total")][Range(0,12)]
	public int NewLPTotal;
	float LPAngleToTurnTo;
	[Tooltip("Drag Life Points Slider here")]
	public Slider LPSlider;
	[Tooltip("Drag Life Points Wheel text")]
	public Text LPWheelText;

	[Space]
	public GameObject ChooseMonsterMenu;
	float Speed = 0.01f;
	GameObject RefMonsterBoard;
	#endregion

	void Start () {
		//Automatically finds the GameObject in the scene
		RefVPWheel = GameObject.Find ("MonsterManager").transform.Find ("VictoryPointsWheel").gameObject;
		RefLPWheel = GameObject.Find ("MonsterManager").transform.Find ("LifePointsWheel").gameObject;
		RefMonsterBoard = GameObject.Find ("MonsterManager").transform.Find ("MonsterBoard").gameObject;

		NewLPTotal = RefMonsterBoard.GetComponent<MonsterDisplay>().monster.setupLifePoints;
		LPSlider.value = NewLPTotal;
		CurrentVPTotal = -1;
		SetWheelsPosition ();
	}

	void FixedUpdate() {
		NewVPTotal = Mathf.RoundToInt (VPSlider.value);
		VPWheelText.text = NewVPTotal.ToString ();
		if (CurrentVPTotal == NewVPTotal) {
			RefVPWheel.transform.rotation = Quaternion.Slerp (RefVPWheel.transform.rotation, Quaternion.Euler (0, 0, VPAngleToTurnTo), Time.time * Speed);
		}
		if (CurrentVPTotal != NewVPTotal) {
			NewVPAngle ();
			CurrentVPTotal = NewVPTotal;
		}

		NewLPTotal = Mathf.RoundToInt (LPSlider.value);
		LPWheelText.text = NewLPTotal.ToString ();
		if (CurrentLPTotal == NewLPTotal) {
			RefLPWheel.transform.rotation = Quaternion.Slerp (RefLPWheel.transform.rotation, Quaternion.Euler (0, 0, LPAngleToTurnTo), Time.time * Speed);
		}
		if (CurrentLPTotal != NewLPTotal) {
			NewLPAngle ();
			CurrentLPTotal = NewLPTotal;
		}
	}

	public void OpenChooseMonster() {
		ChooseMonsterMenu.SetActive (true);
	}

	void NewVPAngle() {
		#region Z values for Victory Points
		/**
		 * Victory Points	Z
		 *	0  VP			-44
		 *	1  VP			-62
		 *	2  VP			-76
		 *	3  VP			-92
		 *	4  VP			-105
		 *	5  VP			-120
		 *	6  VP			-136
		 *	7  VP			-148
		 *	8  VP			-161
		 *	9  VP			-175
		 *	10 VP			-189
		 *	11 VP			-206
		 *	12 VP			-224
		 *	13 VP			-240
		 *	14 VP			-257
		 *	15 VP			-275
		 *	16 VP			-292
		 *	17 VP			-309
		 *	18 VP			-327
		 *	19 VP			-343
		 *	20 VP			-361
		 */
		#endregion

		if(NewVPTotal == 0) 	{VPAngleToTurnTo = -44f;}
		if(NewVPTotal == 1) 	{VPAngleToTurnTo = -62f;}
		if(NewVPTotal == 2) 	{VPAngleToTurnTo = -76f;}
		if(NewVPTotal == 3) 	{VPAngleToTurnTo = -92f;}
		if(NewVPTotal == 4) 	{VPAngleToTurnTo = -105;}
		if(NewVPTotal == 5) 	{VPAngleToTurnTo = -120;}
		if(NewVPTotal == 6) 	{VPAngleToTurnTo = -136;}
		if(NewVPTotal == 7) 	{VPAngleToTurnTo = -148;}
		if(NewVPTotal == 8) 	{VPAngleToTurnTo = -161;}
		if(NewVPTotal == 9) 	{VPAngleToTurnTo = -175;}
		if(NewVPTotal == 10)	{VPAngleToTurnTo = -189;}
		if(NewVPTotal == 11) 	{VPAngleToTurnTo = -206;}
		if(NewVPTotal == 12)	{VPAngleToTurnTo = -224;}
		if(NewVPTotal == 13) 	{VPAngleToTurnTo = -240;}
		if(NewVPTotal == 14) 	{VPAngleToTurnTo = -257;}
		if(NewVPTotal == 15) 	{VPAngleToTurnTo = -275;}
		if(NewVPTotal == 16) 	{VPAngleToTurnTo = -292;}
		if(NewVPTotal == 17) 	{VPAngleToTurnTo = -309;}
		if(NewVPTotal == 18) 	{VPAngleToTurnTo = -327;}
		if(NewVPTotal == 19) 	{VPAngleToTurnTo = -343;}
		if(NewVPTotal == 20) 	{VPAngleToTurnTo = -361;}
	}

	void NewLPAngle() {
		#region Z Values for Life Points
		/**
		 * Life Points	Z
		 *	0  LP		0
		 *	1  LP		26
		 *	2  LP		54
		 *	3  LP		79
		 *	4  LP		104
		 *	5  LP		129
		 *	6  LP		155
		 *	7  LP		182
		 *	8  LP		206
		 *	9  LP		235
		 *	10 LP		257
		 *	11 LP		288
		 *	12 LP		311
		 */
		#endregion

		if(NewLPTotal == 0) 	{LPAngleToTurnTo = 0f;}
		if(NewLPTotal == 1) 	{LPAngleToTurnTo = 26f;}
		if(NewLPTotal == 2) 	{LPAngleToTurnTo = 54f;}
		if(NewLPTotal == 3) 	{LPAngleToTurnTo = 79f;}
		if(NewLPTotal == 4) 	{LPAngleToTurnTo = 104;}
		if(NewLPTotal == 5) 	{LPAngleToTurnTo = 129;}
		if(NewLPTotal == 6) 	{LPAngleToTurnTo = 155;}
		if(NewLPTotal == 7) 	{LPAngleToTurnTo = 182;}
		if(NewLPTotal == 8) 	{LPAngleToTurnTo = 206;}
		if(NewLPTotal == 9) 	{LPAngleToTurnTo = 235;}
		if(NewLPTotal == 10)	{LPAngleToTurnTo = 257;}
		if(NewLPTotal == 11) 	{LPAngleToTurnTo = 288;}
		if(NewLPTotal == 12)	{LPAngleToTurnTo = 311;}
	}

	public void SetWheelsPosition() {
		#region Position values for VP Wheels position
		/**
		 * Name				  x		  y
		 * --------------------------------
		 * -----			-94		31.5
		 * Alpha Zombie		-94		36
		 * Le Geek			-94		31.5
		 * Pouic			-94		31.5
		 */
		#endregion
		#region Position values for LP Wheels position
		/**
		 * Name				  x		  y
		 * --------------------------------
		 * -----			127		-67
		 * Alpha Zombie		127		-69
		 * Le Geek			127		-72
		 * Pouic			127		-67
		 */
		#endregion

		if(RefMonsterBoard.GetComponent<MonsterDisplay>().monster.name == "-----") {
			RefVPWheel.transform.localPosition = new Vector3 (-94, 31.5f, 0);
			RefLPWheel.transform.localPosition = new Vector3 (127, -67, 0);
		}

		if(RefMonsterBoard.GetComponent<MonsterDisplay>().monster.name == "Alpha Zombie") {
			RefVPWheel.transform.localPosition = new Vector3 (-94, 36, 0);
			RefLPWheel.transform.localPosition = new Vector3 (127, -69, 0);
		}

		if(RefMonsterBoard.GetComponent<MonsterDisplay>().monster.name == "Le Geek") {
			RefVPWheel.transform.localPosition = new Vector3 (-94, 31.5f, 0);
			RefLPWheel.transform.localPosition = new Vector3 (127, -72, 0);
		}

		if(RefMonsterBoard.GetComponent<MonsterDisplay>().monster.name == "Pouic") {
			RefVPWheel.transform.localPosition = new Vector3 (-94, 31.5f, 0);
			RefLPWheel.transform.localPosition = new Vector3 (127, -67, 0);
		}
	}
}
