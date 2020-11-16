using UnityEngine;

[CreateAssetMenu(menuName ="TowerDefence/InitialLevelData", order = 0)]
public class InitialLevelData : ScriptableObject
{
    [SerializeField] private int startingGold;
    [SerializeField] private int startingHearts;
    [SerializeField] private AvailableTowers availableTowers;
    private int currentGold;
    private int currentHearts;

    public int CurrentGold {
        get => currentGold;
        private set => currentGold = value; }

    public int CurrentHearts {
        get => currentHearts;
        private set => currentHearts = value; }    

    public AvailableTowers AvailableTowers {
        get => availableTowers;
        private set => availableTowers = value; }

    private void OnEnable()
    {
        CurrentGold = startingGold;
        CurrentHearts = startingHearts;
    }
}