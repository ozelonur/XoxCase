using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.ScriptableObjects;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class PlayerMovementController : Bear
    {
        #region Serialized Fields

        #endregion

        #region Private Variables

        private PlayerMovementDataScriptableObject _playerMovementData;

        private float _movementSpeed;
        private float _movementRange;

        private KeyCode _moveLeftKey;
        private KeyCode _moveRightKey;

        private RectTransform _rectTransform;

        #endregion

        #region MonoBehavior Methods

        private void Awake()
        {
            _playerMovementData =
                Resources.Load<PlayerMovementDataScriptableObject>(FolderPaths.PlayerMovementDataPath);

            _movementSpeed = _playerMovementData.MovementSpeed;
            _movementRange = _playerMovementData.MovementRange;

            _moveLeftKey = _playerMovementData.MoveLeftKey;
            _moveRightKey = _playerMovementData.MoveRightKey;
            
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (Input.GetKey(_moveLeftKey))
            {
                _rectTransform.localPosition += Vector3.left * (_movementSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(_moveRightKey))
            {
                _rectTransform.localPosition += Vector3.right * (_movementSpeed * Time.deltaTime);
            }

            Vector3 position = _rectTransform.localPosition;
            position = new Vector3(Mathf.Clamp(position.x, -_movementRange, _movementRange),
                position.y, position.z);
            _rectTransform.localPosition = position;
        }

        #endregion
    }
}