using System;
using UnityEngine;

namespace Core.Features.Characters.Enemy.Configs {
	[Serializable]
	public class EnemyCommandConfig {
		[Range(0, 100)] public int Probability;
		public EnemyCommandType Type;
		public int Value;
	}
}