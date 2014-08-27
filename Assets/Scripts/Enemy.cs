using UnityEngine;
using System.Collections;

[System.Serializable]
public class Enemy : MonoBehaviour {
	private const int LIFE_POINT = 2;
	private const float LEVEL1_SPEED = 1.5f;
	private const float LEVEL2_SPEED = 2.8f;
	private const float LEVEL3_SPEED = 4.0f;
	private const float LEVEL4_SPEED = 6.0f;
	private const float LEVEL_MAX_SPEED = 13.0f;
	
	//public Parameter hoge = new Parameter();
	
	public GameObject targetObj;
	public float moveSpeed = 4.0f;
	public int enemyLife = LIFE_POINT;
	private float moveSpeed_plus;
	private Vector3 startPotision;
	
	public enum enemyLevel
	{
		level1		= 100,
		level2		= 200,
		level3		= 300,
		level4		= 400,
		level5		= 500,
		level_MAX	= 600
	}
	
	
	void Start ()
	{
		 //setting enemy position
		startPotision = 
			new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	
	void Update ()
	{
		EnemyController();
	}
	
	
	//Enemy Move
	void EnemyController()
	{
		GameObject playerAttack = targetObj;
		
		//player's Rotation look-on
		transform.LookAt(playerAttack.transform.position);
		
		//Enemy move speed level
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
		
		Vector3 enemyMove = new Vector3(0, 0, moveSpeed_plus);
		transform.Translate(enemyMove * Time.deltaTime);
	}
	
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Bullet")
		{
			 enemyLife =
				EnemyLibrary.BulletAndEnemyCheck( other.gameObject , this.gameObject, startPotision, enemyLife, LIFE_POINT );
		}
		//{ BulletAndEnemyCheck( other.gameObject ); }
		else if(other.tag == "Player")
		{
			EnemyLibrary.PlayerLifeCheck();
			EnemyLibrary.BackEnemyComePos(this.gameObject, startPotision, enemyLife, LIFE_POINT);
		}
		//{ PlayerLifeCheck(); BackEnemyComePos(); }
	}
	

//Don't Delete under programming!!	
/*	
	//enemy life check and bullet delete
	void BulletAndEnemyCheck(GameObject obj)
	{
		//enemy life point 1 delete
		enemyLife --;

		if(enemyLife <= 0)
		{
			BackEnemyComePos();
			//player get 10 point
			GuiDate.scorePoint = GuiDate.scorePoint + 10;	
		}
			
		//Destroy Bullet Object
		Destroy( obj.gameObject );			
						
	}
	
	
	//player life point check
	void PlayerLifeCheck()
	{
		// player life 1 dekete
		PlayerController.playerLife = PlayerController.playerLife - 1;
		//if player life point 0, ****Game Over****
		if(PlayerController.playerLife <= 0 )	{ Debug.Log("player dead"); }
	}
	
	
	//enemy comeback program
	void BackEnemyComePos()
	{
		//enemy position return start position
		this.gameObject.transform.position = startPotision;
		//this enemy's active false
		gameObject.SetActive(false);
		//this enemy's life recovery
			enemyLife = LIFE_POINT;
	}
*/
//Don't Delete under programming!!

	
}