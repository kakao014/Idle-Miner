﻿using pg.im.command;
using pg.im.installer;
using pg.im.model.scene;
using RSG;
using UnityEngine;
using Zenject;

namespace pg.im.view
{
    public class StartupInstaller : MonoInstaller
    {
        [SerializeField]
        public StartupView StartupView;

        public override void InstallBindings()
        {
            Container.DeclareSignal<LoadStaticDataSignal>();
            Container.BindSignal<Promise, LoadStaticDataSignal>().To<LoadStaticDataCommand>((x, promise) => x.Execute(promise)).AsSingle();

            Container.DeclareSignal<LoadUserDataSignal>();
            Container.BindSignal<Promise, LoadUserDataSignal>().To<LoadUserDataCommand>((x, promise) => x.Execute(promise)).AsSingle();

            Container.DeclareSignal<SaveUserDataSignal>();
            Container.BindSignal<SaveUserDataSignal>().To<SaveUserDataCommand>((x) => x.Execute()).AsSingle();

            Container.DeclareSignal<CreateUserDataSignal>();
            Container.BindSignal<CreateUserDataSignalParams, CreateUserDataSignal>().To<CreateUserDataCommand>((x, param) => x.Execute(param)).AsSingle();

            Container.Bind<StartupModel>().AsSingle();

            Container.BindInstance(StartupView);
            Container.BindInterfacesTo<StartupMediator>().AsSingle();
        }
    }
}
