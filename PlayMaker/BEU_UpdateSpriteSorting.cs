//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyActions ")]
	[Tooltip("set the layer order so this enemy appears behind or in front of other objects ")]
	public class BEU_UpdateSpriteSorting : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyActions))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		EnemyActions theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<EnemyActions>();


			if (!everyFrame.Value)
			{
				DoTheMethod();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMethod();
			}
		}

		void DoTheMethod()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.UpdateSpriteSorting(); 
			
		}

	}
}