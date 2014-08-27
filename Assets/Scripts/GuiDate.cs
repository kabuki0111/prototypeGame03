using UnityEngine;
using System.Collections;

public class GuiDate : MonoBehaviour {
	public static int scorePoint = 0;
	public GUIStyle style;
	
	Rect scorePosition = new Rect(30, 10, 100, 25);
	
	void Start ()
	{
		style.fontSize = 20;
		//Player Life write
		scorePosition.y = 35;		
	}
	
	void OnGUI () {		
		//Score Point write
		style.fontStyle = FontStyle.BoldAndItalic;
		GUILayout.Label("Score : " +scorePoint, style);
		

		GUILayout.Label("Life : " +PlayerController.playerLife, style);
		
		if( scorePoint <= 0 )
		{
			scorePoint = 0;
		}
	}
}
