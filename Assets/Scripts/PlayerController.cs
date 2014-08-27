using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {	
	
/******************************************/	
	public GameObject	bullet;
	//player obj
	public GameObject	playerObj;
	public float		length		= 35.0f;
	public static int	playerLife	= 6;
	
	private Vector3 	vec;
	private Vector3 	vec_world;
	
/******************************************/
	
	
	void Update()
	{
		TestInput();
	}

	//test input
	void TestInput()
	{
		PlayerLookAt();
		KeyController();
	}
	
	
//this is test program
/*******************************************/	
	
	//Player rotation
	void PlayerLookAt()
	{
		vec			= Input.mousePosition;
		vec.z		= length;
		vec_world	= Camera.main.ScreenToWorldPoint( vec );
		
		transform.LookAt( vec_world );
	}
	
	
	//player get key
	void KeyController()
	{
		//Player Shot Key
		if( Input.GetMouseButtonUp(0) )
		{
			GameObject b_obj = Instantiate(  bullet ) as GameObject;
			
			b_obj.transform.position	=
				new Vector3( transform.rotation.x , transform.rotation.y , transform.position.z );
			b_obj.transform.rotation	= transform.rotation;
			
			
			playerObj.transform.rotation =
				getLookDirection( playerObj.transform.rotation, vec_world, new Vector3(-1, 0, 0) );
		}
		
	}
	
	
	//cannon rotation
	public Quaternion getLookDirection( Quaternion q, Vector3 axis, Vector3 direction )
	{
		Vector3 v	= q * axis;
		Vector3 nm	= Vector3.Cross( v, direction );
		float	ang	= Vector3.Angle( v, direction );
		return	Quaternion.AngleAxis( ang, nm ) * q;
		
	}


// test
/*******************************************/
	
	void OnGUI()
	{
		GUI.Label( new Rect(Screen.width/2 - 100f, 10, 200f, 36f), vec_world.ToString() );
		GUI.Label( new Rect(Screen.width/2 - 300f, 10, 200f, 36f), vec.ToString() );
		GUI.Label( new Rect(Screen.width/2 - 300f, 40, 200f, 36f), playerObj.transform.rotation.ToString() );
		
	}
	
}
