using UnityEngine;
using UnityEngine.Events;

public class OnKeyDownUnityEvent : MonoBehaviour
{
    [SerializeField] private string keyName;

    public UnityEvent OnDown;

    private void Update()
    {
        if (Input.GetKeyDown(keyName))
        {
            OnDown.Invoke();
        }
    }
}