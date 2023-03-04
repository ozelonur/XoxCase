using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Movement Data", menuName = "Orange Bear/Settings/ Player Movement Data", order = 1)]
    public class PlayerMovementDataScriptableObject : ScriptableObject
    {
        #region Serialized Fields

        [Header("Movement Settings")]
        [SerializeField] private float movementSpeed = 5f;

        [SerializeField] private float movementRange;
        
        [Header("Key Bindings")]
        [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
        [SerializeField] private KeyCode moveRightKey = KeyCode.D;

        #endregion

        #region Properties

        public float MovementSpeed => movementSpeed;
        public float MovementRange => movementRange;
        public KeyCode MoveLeftKey => moveLeftKey;
        public KeyCode MoveRightKey => moveRightKey;

        #endregion
    }
}