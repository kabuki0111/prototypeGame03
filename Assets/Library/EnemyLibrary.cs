using UnityEngine;
using System.Collections;

/*
//Anally and Enemy Parameter
[System.Serializable]
public struct Parameter
{
	//char's obj
	public static GameObject	charObj;
	//move speed
	public static float			charSpeed;
	//char's life point
	public static int			charLife;
	//char's start position
	public static Vector3 		charStartPos;
}
*/


[System.Serializable]
public class EnemyLibrary : MonoBehaviour {
	[System.Serializable]
	public struct Parameter
	{
		//char's obj
		public static GameObject	charObj;
		//move speed
		public static float			charSpeed;
		//char's life point
		public static int			charLife;
		//char's start position
		public static Vector3 		charStartPos;
	}	
	
	
	//enemy life check and bullet delete
	public static int BulletAndEnemyCheck( GameObject bulletObj, GameObject enemyObj, Vector3 enemyStartPos, int afterLifeE, int  befureLifeE )
	{
		//enemy life point 1 delete
		afterLifeE --;

		if( afterLifeE <= 0 )
		{
			afterLifeE = BackEnemyComePos( enemyObj, enemyStartPos, afterLifeE, befureLifeE );
			//player get 10 point
			GuiDate.scorePoint = GuiDate.scorePoint + 10;
		}
			
		//Destroy Bullet Object
		Destroy( bulletObj );
		
		return afterLifeE;
						
	}
	
	
	//player life point check
	public static void PlayerLifeCheck()
	{
		// player life 1 dekete
		PlayerController.playerLife = PlayerController.playerLife - 1;
		//if player life point 0, ****Game Over****
		if(PlayerController.playerLife <= 0 )	{ Debug.Log("player dead"); }
	}
	
	
	//enemy comeback program
	public static int BackEnemyComePos( GameObject enemyObj, Vector3 enemyStartPos, int afterLifeE, int befureLifeE )
	{
		//enemy position return start position
		enemyObj.transform.position = enemyStartPos;
		//this enemy's active false
		enemyObj.SetActive(false);
		//this enemy's life recovery
		afterLifeE = befureLifeE;
		
		return afterLifeE;
	}
	
}
