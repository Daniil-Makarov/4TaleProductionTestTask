using System;
using Core.Features.Characters.Enemy.Configs;
using UnityEngine;

namespace Core.Features.Rooms {
	[CreateAssetMenu(fileName = "RoomsConfig", menuName = "Configs/Rooms")]
	public class RoomsConfig : ScriptableObject {
		public Room[] Rooms;
		
		[Serializable]
		public class Room {
			public EnemyConfig[] EnemyConfigs;
		}
	}
}