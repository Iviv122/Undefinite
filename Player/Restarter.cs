using UnityEngine;

public class Restarter : MonoBehaviour
{
    [SerializeField] DeathTrigger trigger;
    public void OnRestart()
    {
        trigger.Die();
    }
}
