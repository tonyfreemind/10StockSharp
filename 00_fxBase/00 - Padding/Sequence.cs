using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace fx.Base
{
    /// <summary>
    /// <p>Concurrent sequence class used for tracking the progress of
    /// the ring buffer and event processors.Support a number
    /// of concurrent operations including CAS and order writes.</p>
    ///
    /// <p>Also attempts to be more efficient with regards to false
    /// sharing by adding padding around the volatile field.</p>
    /// </summary>
    [StructLayout( LayoutKind.Explicit, Size = 120 )]
    public class Sequence : ISequence
    {
        /// <summary>
        /// Set to -1 as sequence starting point
        /// </summary>
        public const int InitialCursorValue = -1;

        // padding: 56

        [FieldOffset(56)]
        // volatile in the Java version => always use Volatile.Read/Write or Interlocked methods to access this field
        private int _value;

        // padding: 56

        /// <summary>
        /// Construct a new sequence counter that can be tracked across threads.
        /// </summary>
        /// <param name="initialValue">initial value for the counter</param>
        public Sequence( int initialValue = InitialCursorValue )
        {
            _value = initialValue;
        }

        /// <summary>
        /// Current sequence number
        /// </summary>
        public int Value
        {
            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            get => Volatile.Read( ref _value );
        }

        /// <summary>
        /// Perform an ordered write of this sequence.  The intent is
        /// a Store/Store barrier between this write and any previous
        /// store.
        /// </summary>
        /// <param name="value">The new value for the sequence.</param>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public void SetValue( int value )
        {
            // no synchronization required, the CLR memory model prevents Store/Store re-ordering
            _value = value;
        }

        /// <summary>
        /// Performs a volatile write of this sequence.  The intent is a Store/Store barrier between this write and any previous
        /// write and a Store/Load barrier between this write and any subsequent volatile read. 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public void SetValueVolatile( int value )
        {
            Volatile.Write( ref _value, value );
        }

        /// <summary>
        /// Atomically set the value to the given updated value if the current value == the expected value.
        /// </summary>
        /// <param name="expectedSequence">the expected value for the sequence</param>
        /// <param name="nextSequence">the new value for the sequence</param>
        /// <returns>true if successful. False return indicates that the actual value was not equal to the expected value.</returns>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public bool CompareAndSet( int expectedSequence, int nextSequence )
        {
            return Interlocked.CompareExchange( ref _value, nextSequence, expectedSequence ) == expectedSequence;
        }

        /// <summary>
        /// Value of the <see cref="Sequence"/> as a String.
        /// </summary>
        /// <returns>String representation of the sequence.</returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        ///<summary>
        /// Increments the sequence and stores the result, as an atomic operation.
        ///</summary>
        ///<returns>incremented sequence</returns>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public int IncrementAndGet()
        {
            return Interlocked.Increment( ref _value );
        }

        ///<summary>
        /// Increments the sequence and stores the result, as an atomic operation.
        ///</summary>
        ///<returns>incremented sequence</returns>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public int DecrementAndGet()
        {
            return Interlocked.Decrement( ref _value );
        }

        ///<summary>
        /// Increments the sequence and stores the result, as an atomic operation.
        ///</summary>
        ///<returns>incremented sequence</returns>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public int AddAndGet( int value )
        {
            return Interlocked.Add( ref _value, value );
        }
    }
}
