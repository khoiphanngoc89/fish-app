namespace NFC.Application.DependencyManager
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="register">The register.</param>
        void OnInitialize(IDependencyRegister register);
    }
}
