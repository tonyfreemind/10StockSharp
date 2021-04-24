namespace fx.Base
{
    public interface ISequence
    {
        /// <summary>
        /// Current sequence number
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Perform an ordered write of this sequence.  The intent is
        /// a Store/Store barrier between this write and any previous
        /// store.
        /// </summary>
        /// <param name="value">The new value for the sequence.</param>
        void SetValue(int value);

        /// <summary>
        /// Performs a volatile write of this sequence.  The intent is a Store/Store barrier between this write and any previous
        /// write and a Store/Load barrier between this write and any subsequent volatile read. 
        /// </summary>
        /// <param name="value"></param>
        void SetValueVolatile(int value);

        /// <summary>
        /// Atomically set the value to the given updated value if the current value == the expected value.
        /// </summary>
        /// <param name="expectedSequence">the expected value for the sequence</param>
        /// <param name="nextSequence">the new value for the sequence</param>
        /// <returns>true if successful. False return indicates that the actual value was not equal to the expected value.</returns>
        bool CompareAndSet(int expectedSequence, int nextSequence);

        ///<summary>
        /// Increments the sequence and stores the result, as an atomic operation.
        ///</summary>
        ///<returns>incremented sequence</returns>
        int IncrementAndGet();

        ///<summary>
        /// Increments the sequence and stores the result, as an atomic operation.
        ///</summary>
        ///<returns>incremented sequence</returns>
        int AddAndGet(int value);
    }
}