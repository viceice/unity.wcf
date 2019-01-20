using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Unity.Wcf
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer _container;
        private readonly Type _contractType;

        public UnityInstanceProvider(IUnityContainer container, Type contractType)
        {
            _container = container ?? throw new ArgumentNullException("container");
            _contractType = contractType ?? throw new ArgumentNullException("contractType");
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var childContainer =
                instanceContext.Extensions.Find<UnityInstanceContextExtension>().GetChildContainer(_container);

            return childContainer.Resolve(_contractType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            instanceContext.Extensions.Find<UnityInstanceContextExtension>().DisposeOfChildContainer();
        }
    }
}
