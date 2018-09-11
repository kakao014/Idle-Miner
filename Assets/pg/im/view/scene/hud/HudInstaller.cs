﻿using UnityEngine;
using Zenject;

namespace pg.im.view
{
    public class HudInstaller : MonoInstaller
    {
        [SerializeField]
        public HudView HudView;

        public override void InstallBindings()
        {
            Container.BindInstance(HudView);
            Container.BindInterfacesTo<HudMediator>().AsSingle();
        }
    }
}
