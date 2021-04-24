using fx.Localization;
using StockSharp.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace fx.Messages
{
	/* -------------------------------------------------------------------------------------------------------------------------------------------
    * 
    *  Tony 12: OrderPositionEffects
    * 
    * ------------------------------------------------------------------------------------------------------------------------------------------- */


	/// <summary>
	/// Indicates whether the resulting position after a trade should be an opening position or closing position.
	/// </summary>
	[DataContract]
	[Serializable]
	public enum fxOrderPositionEffects
	{
		/// <summary>
		/// Default behaviour.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(LocalizedStrings), Name = LocalizedStrings.DefaultKey, Description = LocalizedStrings.DefaultBehaviourKey)]
		Default = 0,

		/// <summary>
		/// A trade should open a position.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(LocalizedStrings), Name = LocalizedStrings.OpenOnlyKey, Description = LocalizedStrings.PositionEffectOpenOnlyKey)]
		OpenOnly = 1,

		/// <summary>
		/// A trade should bring the position towards zero, i.e. close as much as possible of any existing position and open an opposite position for any remainder.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(LocalizedStrings), Name = LocalizedStrings.CloseOnlyKey, Description = LocalizedStrings.PositionEffectCloseOnlyKey)]
		CloseOnly = 2,

		/// <summary>
		/// Tony: A trade to hedge All Long Positions.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.HedgeLongKey, Description = fxLocalizedStrings.HedgeLongKey)]
		HedgeLong = 3,

		/// <summary>
		/// Tony: A trade to hedge All Short Positions.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.HedgeShortKey, Description = fxLocalizedStrings.HedgeShortKey)]
		HedgeShort = 4,

		/// <summary>
		/// Tony: A trade to hedge All Positions.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.HedgeAllKey, Description = fxLocalizedStrings.HedgeAllKey)]
		HedgeAll = 5,

		/// <summary>
		/// Tony: A trade to Set Safety Net
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.SetSafetyKey, Description = fxLocalizedStrings.SetSafetyKey)]
		SetSafety = 6,

		/// <summary>
		/// Tony: A trade to Set Safety Net
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.SetBreakEvenKey, Description = fxLocalizedStrings.SetBreakEvenKey)]
		SetBreakEven = 7,

		/// <summary>
		/// Tony: A trade to Set Take Profit target
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.SetTakeProfitKey, Description = fxLocalizedStrings.SetTakeProfitKey)]
		SetTakeProfit = 8,

		/// <summary>
		/// Tony: Hedge or Close existing trades and open trades in opposite direction
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.ReverseDirectionKey, Description = fxLocalizedStrings.ReverseDirectionKey)]
		ReverseDirection = 9,

		/// <summary>
		/// Tony: Hedge or Close existing trades and open trades in opposite direction
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.EscapeWithoutLossKey, Description = fxLocalizedStrings.EscapeWithoutLossKey)]
		EscapeWithoutLoss = 10,
	}

	/// <summary>
	/// Tony: close the Positions of the following types
	/// </summary>
	public enum ClosePositionsType
	{
		/// <summary>
		/// Tony: Close All Positions
		/// </summary>
		All = 0,
		/// <summary>
		/// Tony: Close All Lossing Positions
		/// </summary>
		Lossing = 1,
		/// <summary>
		/// Tony: Close All Winning Positions
		/// </summary>
		Winning = 2,
		/// <summary>
		/// Tony: Close All Long
		/// </summary>
		Long = 3,
		/// <summary>
		/// Tony: Close All Short
		/// </summary>
		Short = 4,
		/// <summary>
		/// Tony: Close All Hedge for Long Positions
		/// </summary>
		LongHedge = 5,
		/// <summary>
		/// Tony: Close All Hedge for Short Positions
		/// </summary>
		ShortHedge = 6,
		/// <summary>
		/// Tony: Close All Winning Hedge for Positions
		/// </summary>
		WinningHedge = 7,
		/// <summary>
		/// Tony: Close All Lossing Hedge for Positions
		/// </summary>
		LossingHedge = 8,
		/// <summary>
		/// Tony: Close All Hedge for Positions
		/// </summary>
		AllHedge = 9
	}

	/// <summary>
	/// Sides.
	/// </summary>
	[DataContract]
	[Serializable]
	public enum SidesEx
	{
		/// <summary>
		/// Buy.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(LocalizedStrings), Name = LocalizedStrings.Str403Key)]
		Buy,

		/// <summary>
		/// Sell.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(LocalizedStrings), Name = LocalizedStrings.Str404Key)]
		Sell,


		/* -------------------------------------------------------------------------------------------------------------------------------------------
		* 
		*  Tony 13: Sides
		* 
		* ------------------------------------------------------------------------------------------------------------------------------------------- */


		/// <summary>
		/// Sell.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.CloseBuyKey)]
		CloseBuy,

		/// <summary>
		/// Sell.
		/// </summary>
		[EnumMember]
		[Display(ResourceType = typeof(fxLocalizedStrings), Name = fxLocalizedStrings.CloseSellKey)]
		CloseSell,
	}
}
