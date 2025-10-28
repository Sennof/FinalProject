using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] private GameManager _instance;

    public override void InstallBindings()
    {
        Container.Bind<IGameManager>().FromInstance(_instance).AsSingle();
    }
    
}
