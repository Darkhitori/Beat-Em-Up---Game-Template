//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerCombat ")]
	[Tooltip("equips a weapon ")]
	public class BEU_PC_EquipWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerCombat))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Weapon")]
		public FsmString itemName;	
		public FsmString sfx = ""; 
		public FsmString callMethod = ""; 
		public FsmInt data = 0; 
		public FsmBool isPickup; 
		public FsmGameObject SpawnObjectOnDestroy;
		
		public FsmBool everyFrame;

		PlayerCombat theScript;
		Item item;
		
		public override void Reset()
		{
			gameObject = null;
			itemName = "";
			sfx = "";
			callMethod = "";
			data = 0;
			isPickup = false;
			SpawnObjectOnDestroy = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerCombat>();


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
			item = new Item();
			item.itemName = itemName.Value;
			item.sfx = sfx.Value;
			item.callMethod = callMethod.Value;
			item.data = data.Value;
			item.isPickup = isPickup.Value;
			item.SpawnObjectOnDestroy = SpawnObjectOnDestroy.Value;
			
			var weapon = item;

			theScript.EquipWeapon(weapon); 
			
		}

	}
}