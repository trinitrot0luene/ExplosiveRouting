namespace ExplosiveRouting.Shared
{
    /// <summary>
    /// A generic <see cref="ISuccessResult"/> to signal that an operation was carried out successfully.
    /// </summary>
    public sealed class OkResult : ISuccessResult
    {
        public string Message { get; }

        public OkResult(string message = null)
        {
            Message = message;
        }
    }
}
