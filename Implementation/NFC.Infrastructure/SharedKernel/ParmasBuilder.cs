using Newtonsoft.Json;
using NFC.Application.Shared;
using NFC.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.SharedKernel
{
    /// <summary>
    /// 
    /// </summary>
    public class ParmasBuilder : IParamsBuilder
    {
        /// <summary>
        /// The ignored properties
        /// </summary>
        private IEnumerable<string> ignoredProps;

        /// <summary>
        /// Builds params by input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public IDictionary<string, object> Build<T>(T input)
        {
            return input is IComparable ? Build4Key(input) : Build4Model(input);
        }

        /// <summary>
        /// Builds the params by inputs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputs">The inputs.</param>
        /// <returns></returns>
        public IDictionary<string, object> Build<T>(params T[] inputs)
        {
            return this.ConvertToDictionary(inputs);
        }

        /// <summary>
        /// Registers the ignored properties.
        /// </summary>
        /// <param name="props">The properties.</param>
        public void RegisterIgnoredProp(IEnumerable<string> props)
        {
           this.ignoredProps = props;
        }

        #region Private methods

        /// <summary>
        /// Builds params by the input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private IDictionary<string, object> Build4Model<T>(T input)
        {
            return this.Standardize(this.ConvertToDictionary(input));
        }

        /// <summary>
        /// Convert to dictionary params.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private IDictionary<string, object> ConvertToDictionary<T>(T input)
        {
            var json = JsonConvert.SerializeObject(input);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

        /// <summary>
        /// Standardizes the parmas.
        /// </summary>
        /// <param name="dicMapping"></param>
        /// <returns></returns>
        private IDictionary<string, object> Standardize(IDictionary<string, object> dicMapping)
        {
            if (this.ignoredProps != null)
            {
                foreach (var prop in this.ignoredProps)
                {
                    dicMapping.Remove(prop);
                }
            }

            return dicMapping;
        }

        /// <summary>
        /// Builds params by the key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        private IDictionary<string, object> Build4Key<T>(T input)
        {
            return new Dictionary<string, object>()
            {
                { Const.Id, input }
            };
        }

        #endregion
    }
}
