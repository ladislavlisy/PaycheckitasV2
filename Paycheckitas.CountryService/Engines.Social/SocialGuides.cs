﻿using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Social
{
	public abstract class SocialGuides : GeneralEngineGuides, ISocialGuides
	{
		protected SocialGuides (bool defaultGuides, int validFrom, int validUpto) : 
			base (defaultGuides, validFrom, validUpto)
		{

		}

		public virtual object Clone ()
		{
			SocialGuides other = (SocialGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
