using UnityEngine;
using System.Collections;

public class Anally : MonoBehaviour {
	private const int LIFE_POINT = 2;
	private const float LEVEL1_SPEED = 1.5f;
	private const float LEVEL2_SPEED = 2.8f;
	private const float LEVEL3_SPEED = 4.0f;
	private const float LEVEL4_SPEED = 6.0f;
	private const float LEVEL_MAX_SPEED = 13.0f;
	
	//setting target obj
	public GameObject targetObj;
	public float moveSpeed = 4.0f;
	private float moveSpeed_plus;
	private Vector3 startPotision;
	public int anallyLife = LIFE_POINT;
	
	public enum enemyLevel
	{
		level1 = 100,
		level2 = 200,
		level3 = 300,
		level4 = 400,
		level5 = 500,
		level_MAX = 600
	}
	
	void Awake ()
	{
		//input object start potision	
		startPotision = 
			new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void Update ()
	{
		enemyController();
	}
	
	
	//Anally Move
	void enemyController()
	{
		GameObject playerAttack = targetObj;
		
		transform.LookAt(playerAttack.transform.position);
		
		//Enemy move level
		if( GuiDate.scorePoint <= (int)enemyLevel.level1 )
			moveSpeed_plus = moveSpeed;
		else if( ( GuiDate.scorePoint > (int)enemyLevel.level1 ) && ( GuiDate.scorePoint <= (int)enemyLevel.level2 ) )
			moveSpeed_plus = moveSpeed + LEVEL1_SPEED;
		else if( ( GuiDate.scorePoint > (int)enemyLevel.level2 ) && ( GuiDate.scorePoint <= (int)enemyLevel.level3 ) )
			moveSpeed_plus = moveSpeed + LEVEL2_SPEED;
		else if( ( GuiDate.scorePoint > (int)enemyLevel.level3 ) && ( GuiDate.scorePoint <= (int)enemyLevel.level4 ) )
			moveSpeed_plus = moveSpeed + LEVEL3_SPEED;
		else if( ( GuiDate.scorePoint > (int)enemyLevel.level4 ) && ( GuiDate.scorePoint <= (int)enemyLevel.level5 ) )
			moveSpeed_plus = moveSpeed + LEVEL4_SPEED;
		else if( ( GuiDate.scorePoint > (int)enemyLevel.level5 ) && ( GuiDate.scorePoint <= (int)enemyLevel.level_MAX ) )
			moveSpeed_plus = moveSpeed + LEVEL_MAX_SPEED;
		
		Vector3 enemyMove = new Vector3( 0, 0, moveSpeed_plus );
		transform.Translate( enemyMove * Time.deltaTime );
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if( other.tag=="Bullet" ) { BulletAndAnallyCheckFlag( other.gameObject ); }
		else if( other.tag == "Player" ) { PlayerAndAnallyCheckFlag(true); }	
	}
	
	
	void BulletAndAnallyCheckFlag(GameObject obj)
	{
		if(obj.tag == "Bullet")
		{
			anallyLife --;
			//Destroy Bullet Object
			Destroy( obj.gameObject );
			
			if( anallyLife <= 0 )
			{
				transform.position = startPotision;
				anallyLife = LIFE_POINT;
				GuiDate.scorePoint = GuiDate.scorePoint - 10;
				gameObject.SetActive(false);
			}	
			
		}
		
	}
	
	
	void PlayerAndAnallyCheckFlag(bool flag)
	{
		if(flag == true)
		{
			transform.position = startPotision;
			GuiDate.scorePoint = GuiDate.scorePoint + 10;
			gameObject.SetActive(false);
		}
		
	
	}
	
	
	
}