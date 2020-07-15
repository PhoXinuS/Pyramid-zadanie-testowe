using UnityEngine;
 using UnityEngine.Events;
 
 public class OnGameOverUnityEvent : MonoBehaviour
 {
     public UnityEvent OnGameOver;
 
     private void Start()
     {
         Events.GameOver += Activate;
     }
 
     private void Activate()
     {
         OnGameOver.Invoke();
     }
 	
     private void OnDisable()
     {
         Events.GameOver -= Activate;
     }
 }