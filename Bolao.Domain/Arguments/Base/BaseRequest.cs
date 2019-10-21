using System;

namespace Bolao.Domain.Arguments.Base
{
    public abstract class BaseRequest
    {
        protected Guid CorrelationId;

        public void SetCorrelationId(Guid? correlationId)
        {
            this.CorrelationId = correlationId.HasValue ? correlationId.Value : Guid.NewGuid();
        }

        public Guid GetCorrelationId()
        {
            return this.CorrelationId;
        }
    }
}