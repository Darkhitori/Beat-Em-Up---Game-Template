//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyAI ")]
	[Tooltip(" ")]
	public class BEU_Hit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyAI))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("DamageObject")]
		public FsmInt damage;
		public FsmFloat range;
		public AttackType attackType;
		public FsmGameObject inflictor;
		public FsmFloat comboResetTime;
		
		public FsmBool everyFrame;

		EnemyAI theScript;
		DamageObject dam;

		public override void Reset()
		{
			gameObject = null;
			damage = null;
			range = null;
			attackType = AttackType.Default;
			inflictor = null;
			comboResetTime = .5f;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<EnemyAI>();
			

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
			dam = new DamageObject(damage.Value, attackType, inflictor.Value);
			dam.range = range.Value;
			dam.comboResetTime = comboResetTime.Value;
			var dObject = dam;
			theScript.Hit(dObject); 
			
		}

	}
}