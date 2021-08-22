//using System;
//using System.Runtime.Serialization;

//using Ecng.Serialization;

//using StockSharp.Localization;
//using StockSharp.Messages;

//namespace fx.Messages
//{
//    /// <summary>
//    /// The message containing the information for the order registration.
//    /// </summary>
//    [System.Runtime.Serialization.DataContract]
//    [Serializable]
//    public class fxOrderRegisterMessage : OrderRegisterMessage
//    {

//        /// <summary>
//        /// Order Effect on Positions
//        /// </summary>
//        [DataMember]
//        public fxOrderPositionEffects? OrderEffectOnPositions { get; set; }
//        
//        /// <summary>
//        /// Initializes a new instance of the <see cref="OrderRegisterMessage"/>.
//        /// </summary>
//        public fxOrderRegisterMessage() : base( MessageTypes.OrderRegister )
//        {
//        }

//        /// <summary>
//        /// Initialize <see cref="OrderRegisterMessage"/>.
//        /// </summary>
//        /// <param name="type">Message type.</param>
//        protected fxOrderRegisterMessage( MessageTypes type ) : base( type )
//        {
//        }

//        /// <summary>
//        /// Create a copy of <see cref="OrderRegisterMessage"/>.
//        /// </summary>
//        /// <returns>Copy.</returns>
//        public override Message Clone()
//        {
//            var clone = new fxOrderRegisterMessage(Type);
//            CopyTo( clone );
//            return clone;
//        }

//        /// <summary>
//        /// Copy the message into the <paramref name="dest" />.
//        /// </summary>
//        /// <param name="dest">The object, to which copied information.</param>
//        public void CopyTo( fxOrderRegisterMessage dest )
//        {
//            base.CopyTo( dest );

//            dest.OrderEffectOnPositions = OrderEffectOnPositions;
//            dest.ClosePositionType      = ClosePositionType;
//        }

//        /// <inheritdoc />
//        public override string ToString()
//        {
//            var str = base.ToString() + $",Price={Price},Side={Side},Vol={Volume}/{VisibleVolume}/{MinOrderVolume},Till={TillDate},TIF={TimeInForce},MM={IsMarketMaker},SLP={Slippage},MN={IsManual}";

//            if ( PositionEffect != null )
//                str += $",PosEffect={PositionEffect.Value}";

//            if ( PostOnly != null )
//                str += $",PostOnly={PostOnly.Value}";

//            if ( Leverage != null )
//                str += $",Leverage={Leverage.Value}";

//            return str;
//        }
//    }
//}