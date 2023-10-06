namespace VUDK.Features.Main.InputSystem.MobileInputs
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using VUDK.Features.Main.InputSystem.MobileInputs.Controls;

    public class MobileAnalog : MobileControlBase, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField, Min(0f), 
            Tooltip("Maximum distance the analog can move from the center of the analog.")]
        private float _rangeRadius;

        [SerializeField, Min(0f), 
            Tooltip("The area in the center of the analog where the analog will not move.")]
        private float _deadzone;

        private Vector2 _startAnalogPosition;

        private bool _isAnalogFollowing;

        private void Awake()
        {
            _startAnalogPosition = transform.position;
        }

        private void Update()
        {
            if(_isAnalogFollowing)
                AnalogFingerFollow();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isAnalogFollowing = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isAnalogFollowing = false;
            ResetAnalogPosition();
        }

        private void AnalogFingerFollow()
        {
            Vector2 fingerPosition = InputsManager.Inputs.Touches.TouchPosition.ReadValue<Vector2>();
            Vector2 offset = fingerPosition - _startAnalogPosition;

            // The distance from the center of the analog to the finger position can easily be calculated using the magnitude (the length of the vector) of the offset vector.
            float distance = offset.magnitude;

            if (distance > _rangeRadius)
            {
                offset = offset.normalized * _rangeRadius;
                fingerPosition = _startAnalogPosition + offset;
            }

            transform.position = fingerPosition;

            CalculateInputDirection(offset);
        }

        protected override void CalculateInputDirection(Vector2 startingInputPosition)
        {
            if (IsDeadzone(startingInputPosition))
                return;

            InputDirection = startingInputPosition / _rangeRadius;
            OnInputDirection?.Invoke(InputDirection);
        }

        private bool IsDeadzone(Vector2 position)
        {
            return position.magnitude < _deadzone;
        }

        private void ResetAnalogPosition()
        {
            transform.position = _startAnalogPosition;
        }
    }
}