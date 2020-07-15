using UnityEngine;

[RequireComponent(typeof(IInput))]
public class OnInputPressIncreaseVector2SO : MonoBehaviour
{
    public FloatSO increaseSpeed;
    public Vector2SO vectorToIncrease;

    private IInput input;
    
    private void Start()
    {
        input = gameObject.GetComponent<IInput>();
    }

    private void Update()
    {
        if (input.inputIsActive)
        {
            float valueToIncrease = increaseSpeed.variable * Time.deltaTime;
            vectorToIncrease.variable.x += valueToIncrease;
            vectorToIncrease.variable.y += valueToIncrease;
        }
    }
}
