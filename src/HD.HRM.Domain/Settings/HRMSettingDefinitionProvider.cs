﻿using Volo.Abp.Settings;

namespace HD.HRM.Settings;

public class HRMSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HRMSettings.MySetting1));
    }
}
