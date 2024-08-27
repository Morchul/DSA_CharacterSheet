using UnityEngine;

public class ActivateDefaultIncreaserMenu : CharacterContainerMenu
{
    [SerializeField]
    private CharacterContainer characterContainer;

    public override void Select()
    {
        base.Select();

        characterContainer.ActivateIncreaser(new DefaultIncreaserFactory());
        Debug.Log("Activate Increaser");
    }

    public override void ActivateIncreaser(IIncreaser increaser)
    {
        base.ActivateIncreaser(increaser);

        this.IsEnabled = false;
    }

    public override void DeactivateIncreaser()
    {
        base.DeactivateIncreaser();

        this.IsEnabled = true;
    }
}
