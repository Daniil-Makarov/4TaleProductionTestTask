using Core.Features.Characters.Enemy.Configs;
using UnityEditor;

namespace Core.Editor {
	[CustomEditor(typeof(EnemyConfig))]
	public class EnemyConfigEditor : UnityEditor.Editor {
		public override void OnInspectorGUI() {
			serializedObject.Update();
			
			SerializedProperty sprite = serializedObject.FindProperty(nameof(EnemyConfig.Sprite));
			SerializedProperty maxHealth = serializedObject.FindProperty(nameof(EnemyConfig.MaxHealth));
			SerializedProperty actions = serializedObject.FindProperty(nameof(EnemyConfig.Commands));
			
			if (maxHealth.intValue < 1) maxHealth.intValue = 1;
			
			int probabilitySum = 0;
			for (int i = 0; i < actions.arraySize; i++) {
				int probability = actions
					.GetArrayElementAtIndex(i)
					.FindPropertyRelative(nameof(EnemyCommandConfig.Probability)).intValue;
				
				probabilitySum += probability;
			}
			
			EditorGUILayout.PropertyField(sprite);
			EditorGUILayout.PropertyField(maxHealth);
			if (probabilitySum != 100) {
				EditorGUILayout.HelpBox("Sum of probabilities must be equal to 100", MessageType.Error);
			}
			EditorGUILayout.PropertyField(actions);
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}