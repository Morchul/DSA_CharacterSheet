using DSA.Character;

public interface ICharacterContainerElement
{
    public void SetCharacter(Character character);
    public void ActivateIncreaser(IIncreaser increaser);
    public void DeactivateIncreaser();
}
