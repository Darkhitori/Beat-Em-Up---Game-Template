﻿//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerMovement ")]
	[Tooltip("returns the current direction ")]
	public class BEU_PM_getCurrentDirection : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerMovement))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		public DIRECTION currentDirection;
		
		public FsmBool everyFrame;

		PlayerMovement theScript;
  

		public override void Reset()
		{
			gameObject = null;
			currentDirection = DIRECTION.Right;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerMovement>();


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

			currentDirection = theScript.getCurrentDirection(); 
			
		}

	}
}