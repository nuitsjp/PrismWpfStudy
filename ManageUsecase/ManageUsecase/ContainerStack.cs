using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DryIoc;
using ImTools;

namespace ManageUsecase
{
    public class ContainerStack : IContainer
    {
        private Stack<IContainer> Containers { get; } = new Stack<IContainer>();
        private IContainer Current { get; set; }

        public ContainerStack(IContainer container)
        {
            Containers.Push(container);
            Current = container;
        }

        public IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations()
        {
            return Current.GetServiceRegistrations();
        }

        public void Register(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered ifAlreadyRegistered,
            bool isStaticallyChecked)
        {
            Current.Register(factory, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked);
        }

        public bool IsRegistered(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
        {
            return Current.IsRegistered(serviceType, serviceType, factoryType, condition);
        }

        public void Unregister(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
        {
            Current.Unregister(serviceType, serviceKey, factoryType, condition);
        }

        public object Resolve(Type serviceType, bool ifUnresolvedReturnDefault)
        {
            return Current.Resolve(serviceType, ifUnresolvedReturnDefault);
        }

        public object Resolve(Type serviceType, object serviceKey, bool ifUnresolvedReturnDefault, Type requiredServiceType,
            RequestInfo preResolveParent, IScope scope)
        {
            return Resolve(
                serviceType, serviceKey, ifUnresolvedReturnDefault, requiredServiceType, preResolveParent, scope);
        }

        public IEnumerable<object> ResolveMany(Type serviceType, object serviceKey, Type requiredServiceType, object compositeParentKey,
            Type compositeParentRequiredType, RequestInfo preResolveParent, IScope scope)
        {
            return Current.ResolveMany(serviceType, serviceKey, requiredServiceType, compositeParentKey, compositeParentRequiredType, preResolveParent, scope);
        }

        public void Dispose()
        {
            Current = null;
            foreach (var container in Containers)
            {
                container.Dispose();
            }
            Containers.Clear();
        }

        public IContainer With(Func<Rules, Rules> configure = null, IScopeContext scopeContext = null)
        {
            return Current.With(configure, scopeContext);
        }

        public IContainer WithNoMoreRegistrationAllowed(bool ignoreInsteadOfThrow = false)
        {
            return Current.WithNoMoreRegistrationAllowed(ignoreInsteadOfThrow);
        }

        public IContainer WithoutCache()
        {
            return Current.WithoutCache();
        }

        public IContainer WithoutSingletonsAndCache()
        {
            return Current.WithoutSingletonsAndCache();
        }

        public IContainer WithRegistrationsCopy(bool preserveCache = false)
        {
            return Current.WithRegistrationsCopy(preserveCache);
        }

        public IContainer OpenScope(object name = null, Func<Rules, Rules> configure = null)
        {
            var container = Current.OpenScope(name, configure);
            Containers.Push(container);
            Current = container;
            return container;
        }

        public IContainer CreateFacade()
        {
            return Current.CreateFacade();
        }

        public Factory ResolveFactory(Request request)
        {
            return Current.ResolveFactory(request);
        }

        public Factory GetServiceFactoryOrDefault(Request request)
        {
            return Current.GetServiceFactoryOrDefault(request);
        }

        public IEnumerable<KV<object, Factory>> GetAllServiceFactories(Type serviceType, bool bothClosedAndOpenGenerics = false)
        {
            return Current.GetAllServiceFactories(serviceType, bothClosedAndOpenGenerics);
        }

        public Factory GetWrapperFactoryOrDefault(Type serviceType)
        {
            return Current.GetWrapperFactoryOrDefault(serviceType);
        }

        public Factory[] GetDecoratorFactoriesOrDefault(Type serviceType)
        {
            return Current.GetDecoratorFactoriesOrDefault(serviceType);
        }

        public Expression GetDecoratorExpressionOrDefault(Request request)
        {
            return Current.GetDecoratorExpressionOrDefault(request);
        }

        public object InjectPropertiesAndFields(object instance, PropertiesAndFieldsSelector propertiesAndFields)
        {
            return Current.InjectPropertiesAndFields(instance, propertiesAndFields);
        }

        public Type GetWrappedType(Type serviceType, Type requiredServiceType)
        {
            return Current.GetWrappedType(serviceType, requiredServiceType);
        }

        public void CacheFactoryExpression(int factoryID, Expression factoryExpression)
        {
            Current.CacheFactoryExpression(factoryID, factoryExpression);
        }

        public Expression GetCachedFactoryExpressionOrDefault(int factoryID)
        {
            return Current.GetCachedFactoryExpressionOrDefault(factoryID);
        }

        public Expression GetOrAddStateItemExpression(object item, Type itemType = null, bool throwIfStateRequired = false)
        {
            return Current.GetOrAddStateItemExpression(item, itemType, throwIfStateRequired);
        }

        public int GetOrAddStateItem(object item)
        {
            return Current.GetOrAddStateItem(item);
        }

        public ContainerWeakRef ContainerWeakRef => Current.ContainerWeakRef;
        public Rules Rules => Current.Rules;
        public Request EmptyRequest => Current.EmptyRequest;
        public object[] ResolutionStateCache => Current.ResolutionStateCache;
        public IScopeContext ScopeContext => Current.ScopeContext;
    }
}