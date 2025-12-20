using UnityEngine;
using Zenject;

public class MoneyManagerInstaller : MonoInstaller
{
    [SerializeField] private MoneyManager _instance;

    public override void InstallBindings()
    {
        Container.Bind<IMoneyManager>().FromInstance(_instance).AsSingle();
    }
}
