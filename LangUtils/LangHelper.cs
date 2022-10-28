﻿using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityCN.LangUtils
{

	internal static class LangHelper
	{
		internal static string GetText(string key)
		{
			return LangLoader.Translations["Mods.CalamityCN." + key].GetTranslation(Language.ActiveCulture);
		}

		internal static string GetTextValue(string key, params object[] args)
		{
			return LangHelper.GetModTextValue(CalamityCN.Instance, key, args);
		}

		private static string GetModTextValue(Mod mod, string key, params object[] args)
		{
			return Language.GetTextValue("Mods." + mod.Name + "." + key, args);
		}

	}
}
