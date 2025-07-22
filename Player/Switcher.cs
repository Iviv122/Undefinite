using UnityEngine;

public class Switcher : MonoBehaviour {
    [SerializeField] SwitchStateBus bus;
    // new unity system by default is funny XDD
    public void OnAttack()
    {
        bus.Switch();
        Debug.Log("Switch!");
    }
}