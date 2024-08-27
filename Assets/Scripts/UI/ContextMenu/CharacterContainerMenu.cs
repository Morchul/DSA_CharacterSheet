using DSA.Character;

public class CharacterContainerMenu : ContextMenuItem, ICharacterContainerElement
{
    protected Character character;

    public virtual void ActivateIncreaser(IIncreaser increaser)
    {
        
    }

    public virtual void DeactivateIncreaser()
    {
        
    }

    public virtual void SetCharacter(Character character)
    {
        this.character = character;
    }
}
