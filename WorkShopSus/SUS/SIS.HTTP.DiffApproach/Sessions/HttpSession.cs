using SIS.HTTP.DiffApproach.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.DiffApproach.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> sessionParameters;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));

            this.Id = id;
            this.sessionParameters = new Dictionary<string, object>();
        }
        public string Id { get; }

        public object GetParameter (string parameterName)
        {
            CoreValidator.ThrowIfNullOrEmpty(parameterName, nameof(parameterName));

            return this.sessionParameters[parameterName];
        }

        public void AddParameter(string parameterName, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(parameterName, nameof(parameterName));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));

            //this object is override(example eshop basket is overrided)
            this.sessionParameters[parameterName] = parameter;
        }

        public void ClearParameter()
        {
            this.sessionParameters.Clear();
        }

        public bool ContainsParameter(string parameterName)
        {
            return this.sessionParameters.ContainsKey(parameterName);
        }
    }
}
