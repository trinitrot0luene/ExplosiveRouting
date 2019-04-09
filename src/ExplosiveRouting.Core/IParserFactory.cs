using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Core
{
    public interface IParserFactory
    {
        /// <summary>
        /// Returns an instance of <see cref="IParser"/> with default options configured.
        /// </summary>
        /// <returns></returns>
        IParser Create();

        /// <summary>
        /// Returns a configured instance of <see cref="IParser"/>.
        /// </summary>
        /// <param name="configureOptions">Custom configuration options to be applied.</param>
        /// <returns></returns>
        IParser Create(Action<IParserOptions> configureOptions);
    }
}
