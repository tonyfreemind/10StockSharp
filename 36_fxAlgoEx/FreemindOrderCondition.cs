namespace StockSharp.Algo.Testing
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    using Ecng.Collections;
    using fx.Localization;
    using StockSharp.Localization;
    using StockSharp.Messages;

    /// <summary>
    /// <see cref="IMarketEmulator"/> order condition.
    /// </summary>
    [Serializable]
    [DataContract]
    [DisplayNameLoc( LocalizedStrings.Str2264Key, "Freemind" )]
    public class FreemindOrderCondition : OrderCondition, IStopLossOrderCondition, ITakeProfitOrderCondition
    {
        /// <summary>
        /// Is take profit.
        /// </summary>
        [DataMember]
        [Display(
            ResourceType = typeof( LocalizedStrings ),
            Name = LocalizedStrings.TakeProfitKey,
            Description = LocalizedStrings.TakeProfitKey,
            GroupName = LocalizedStrings.Str225Key,
            Order = 0 )]
        public bool IsTakeProfit
        {
            get => ( bool? ) Parameters.TryGetValue( nameof( IsTakeProfit ) ) == true;
            set => Parameters[ nameof( IsTakeProfit ) ] = value;
        }

        /// <summary>
        /// Stop-price.
        /// </summary>
        [DataMember]
        [Display(
            ResourceType = typeof( LocalizedStrings ),
            Name = LocalizedStrings.StopPriceKey,
            Description = LocalizedStrings.Str1693Key,
            GroupName = LocalizedStrings.Str225Key,
            Order = 1 )]
        public decimal? StopPrice
        {
            get => ( decimal? ) Parameters.TryGetValue( nameof( StopPrice ) );
            set => Parameters[ nameof( StopPrice ) ] = value;
        }

        /// <summary>
        /// Number of pips to take profit
        /// </summary>
        [DataMember]
        [Display(
            ResourceType = typeof( LocalizedStrings ),
            Name = LocalizedStrings.TakeProfitKey,
            Description = LocalizedStrings.TakeProfitKey,
            GroupName = LocalizedStrings.Str225Key,
            Order = 2 )]
        public decimal? TakeProfitPips
        {
            get => ( decimal? ) Parameters.TryGetValue( nameof( TakeProfitPips ) );
            set => Parameters[ nameof( TakeProfitPips ) ] = value;
        }


        /// <summary>
        /// Number of Pips for Stop Loss
        /// </summary>
        [DataMember]
        [Display(
            ResourceType = typeof( LocalizedStrings ),
            Name = LocalizedStrings.StopPriceKey,
            Description = LocalizedStrings.Str1693Key,
            GroupName = LocalizedStrings.Str225Key,
            Order = 3 )]
        public decimal? StopLossPips
        {
            get => ( decimal? ) Parameters.TryGetValue( nameof( StopLossPips ) );
            set => Parameters[ nameof( StopLossPips ) ] = value;
        }

        /// <summary>
        /// Number of Pips for Stop Loss
        /// </summary>
        [DataMember]
        [Display(
            ResourceType = typeof( LocalizedStrings ),
            Name = fxLocalizedStrings.EscapeWithoutLossKey,
            Description = fxLocalizedStrings.EscapeWithoutLossKey,
            GroupName = LocalizedStrings.Str225Key,
            Order = 4 )]
        public bool? WithEscape
        {
            get => ( bool? ) Parameters.TryGetValue( nameof( WithEscape ) );
            set => Parameters[ nameof( WithEscape ) ] = value;
        }

        decimal? IStopLossOrderCondition.ClosePositionPrice { get; set; }
        decimal? IStopLossOrderCondition.ActivationPrice { get; set; }
        bool IStopLossOrderCondition.IsTrailing { get; set; }

        decimal? ITakeProfitOrderCondition.ClosePositionPrice { get; set; }
        decimal? ITakeProfitOrderCondition.ActivationPrice { get; set; }
        bool ITakeProfitOrderCondition.IsTrailing { get; set; }
    }
}

