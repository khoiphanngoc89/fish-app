using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParamsBuilder
    {
        /// <summary>
        /// Registers ingored property.
        /// </summary>
        /// <param name="props"></param>
        void RegisterIgnoredProp(IEnumerable<string> props);

        /// <summary>
        /// Builds parmas by input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        IDictionary<string, object> Build<T>(T input);

        /// <summary>
        /// Builds params by list of input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputs">The inputs.</param>
        /// <returns></returns>
        IDictionary<string, object> Build<T>(params T[] inputs);
    }
}
